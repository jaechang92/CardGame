using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static public GameManager instance;

    public List<GameObject> managerPool;

    public GameObject nullPrefab;

    public GameObject playerParentPool;
    public GameObject enemyParentPool;
    public List<GameObject> PlayerCardPool;      // 사용하지 않은 카드덱
    private List<GameObject> PlayerCardTombPool; // 파괴된 카드덱
    public List<GameObject> EnemyCardPool;       // 사용하지 않은 카드덱
    private List<GameObject> EnemyCardTombPool;  // 파괴된 카드덱

    public List<GameObject> PlayerGetCardPool;   // 손에 들고있는 카드덱
    public List<GameObject> EnemyGetCardPool;    // 손에 들고있는 카드덱


    public int playerHP = 30, enemyHp = 30;

    public GameObject startThreeCardGrid;
    public GameObject decOfHand;
    public bool isRunning = false;
    private int turnNumber = 0;
    private int cardIndex = 0;
    public bool playerTurn = true;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }



    void Start () {
        //CardCreate("Player", 10);

    }
	
	// Update is called once per frame
	void Update () {

        if (isRunning)
        {
            GameLoop();
        }

    }



    public void CardCreate(string master)
    {
        if (master == "Player")
        {
            int count = ObjectPool.instance.CardDec.Count;
            if (PlayerCardPool.Count < count)
            {
                int num = count - PlayerCardPool.Count;
                for (int i = 0; i < num; i++)
                {
                    GameObject obj = Instantiate(nullPrefab, playerParentPool.transform);
                    obj.GetComponent<CardState>().CardSetup(ObjectPool.instance.CardDec[i].GetComponent<CardState>());
                    PlayerCardPool.Add(obj);
                }
            }
        }

        //if (master == "Enemy")
        //{
            
        //    if (EnemyCardPool.Count < count)
        //    {
        //        int num = count - EnemyCardPool.Count;
        //        for (int i = 0; i < num; i++)
        //        {
        //            GameObject obj = Instantiate(nullPrefab, enemyParentPool.transform);
        //            EnemyCardPool.Add(obj);
        //        }
        //    }
        //}

    }


    public void GameLoop()
    {
        if (turnNumber == 0)
        {
            /// 덱 초기화
            CardCreate("Player");
            
            ///
            /// 플레이어 카드 3장을 뽑는다.
            ///

            /// 
            /// 적의 카드를 3장 뽑는다.
            ///


            for (int i = 0; i < 3; i++)
            {
                PlayerGetCardPool.Add(DrawCard(PlayerCardPool));
                PlayerGetCardPool[i].transform.SetParent(startThreeCardGrid.transform);
                //EnemyGetCardPool.Add(DrawCard(EnemyCardPool));
            }
            turnNumber++;
        }

        //플레이어 턴일때와 아닐때
        if (playerTurn && turnNumber > 0)
        {

        }
        else if(!playerTurn && turnNumber > 0)
        {

        }


        if (playerHP <=0 || enemyHp <=0)
        {
            GameEnd();
        }
        

    }

   private void GameEnd()
    {
        isRunning = false;
        playerHP = 30;
        enemyHp = 30;
        turnNumber = 0;
    }


    private GameObject DrawCard(List<GameObject> _CardPoolName)
    {
        cardIndex = Random.Range(0, _CardPoolName.Count - 1);
        GameObject dCard = _CardPoolName[cardIndex];
        _CardPoolName.Remove(dCard);
        return dCard;
    }

    public void TestDraw()
    {
        cardIndex = Random.Range(0, PlayerCardPool.Count - 1);
        GameObject dCard = PlayerCardPool[cardIndex];
        PlayerCardPool.Remove(dCard);
        PlayerGetCardPool.Add(dCard);
    }

}
