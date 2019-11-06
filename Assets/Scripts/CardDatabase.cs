using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour {

    static public CardDatabase instance;
    public List<Card> cardList = new List<Card>();

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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public Card FoundCardData(int ID)
    {
        foreach (Card item in cardList)
        {
            if (item.cardID == ID)
            {
                return item;
            }
            
        }
        return null;
    }
}
