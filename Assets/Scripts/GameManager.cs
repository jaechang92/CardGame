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

   
}
