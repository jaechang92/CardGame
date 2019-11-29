using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static public GameManager instance;

    public List<GameObject> managerPool;

    public GameObject nullPrefab;

    public GameObject playerParentPool;
    public GameObject enemyParentPool;
    public List<GameObject> PlayerCardPool;
    public List<GameObject> EnemyCardPool;


    public bool isRunning = false;
    private int turnNumber = 0;
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

        while (isRunning)
        {
            if (turnNumber == 0)
            {
                ///
                /// 플레이어 카드 3장을 뽑는다.
                ///

                /// 
                /// 적의 카드를 3장 뽑는다.
                ///

                turnNumber++;
            }


        }


    }

   
}
