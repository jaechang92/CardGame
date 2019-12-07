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

    public GameObject [] FieldParent = new GameObject[2];
    public List<GameObject> PlayerField;         // 필드에 있는 카드덱
    public List<GameObject> EnemyField;          // 필드에 있는 카드덱


    public int playerHP = 30, enemyHp = 30;

    public GameObject startThreeCardGrid;
    public GameObject decOfHand;
    public bool isRunning = false;
    private int turnNumber = 0;
    private int cardIndex = 0;
    public bool playerTurn = true;
    public bool drawOnOff = false;
    private GameObject nullGameObject;
    public CardDecGrid CardDecGrid;
    public CardDecGrid FieldDecGrid;
    public CardDecGrid EnemyDecGrid;


    public List<GameObject> AttackList;

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
        CardDecGrid = decOfHand.GetComponent<CardDecGrid>();
        FieldDecGrid = FieldParent[0].GetComponent<CardDecGrid>();
        EnemyDecGrid = FieldParent[1].GetComponent<CardDecGrid>();
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
                DrawCard(PlayerCardPool);
                PlayerGetCardPool[i].transform.SetParent(startThreeCardGrid.transform);
                startThreeCardGrid.GetComponent<CardDecGrid>().ObjectToSort.Add(PlayerGetCardPool[i]);
                //EnemyGetCardPool.Add(DrawCard(EnemyCardPool));
            }
            startThreeCardGrid.GetComponent<CardDecGrid>().OneSort();
            turnNumber++;
        }
        else
        {
            //플레이어 턴일때와 아닐때
            if (playerTurn)
            {
                if (drawOnOff)
                {
                    DrawCard(PlayerCardPool);
                    CardDecGrid.SortObj();
                    drawOnOff = false;

                }
                
            }
            else if (!playerTurn)
            {

            }


            if (playerHP <= 0 || enemyHp <= 0)
            {
                GameEnd();
            }

        }

    }

   private void GameEnd()
    {
        isRunning = false;
        playerHP = 30;
        enemyHp = 30;
        turnNumber = 0;
    }


    private void DrawCard(List<GameObject> _CardPoolName)
    {
        if (PlayerCardPool.Count >= 1)
        {
            cardIndex = Random.Range(0, _CardPoolName.Count - 1);
            GameObject dCard = _CardPoolName[cardIndex];
            _CardPoolName.Remove(dCard);
            PlayerGetCardPool.Add(dCard);
            CardDecGrid.ObjectToSort.Add(dCard);
            dCard.transform.SetParent(decOfHand.transform);
        }
        else
        {
            Debug.Log("더이상 뽑을 덱이 없습니다.");
        }

    }

    public void TestDraw()
    {
        if (PlayerCardPool.Count >= 1)
        {
            cardIndex = Random.Range(0, PlayerCardPool.Count - 1);
            GameObject dCard = PlayerCardPool[cardIndex];
            PlayerCardPool.Remove(dCard);
            PlayerGetCardPool.Add(dCard);
        }
        else
        {
            Debug.Log("더이상 뽑을 덱이 없습니다.");
        }
    }


    //IEnumerator AttackPool()
    //{
    //    //yield return new wait
    //}

}
