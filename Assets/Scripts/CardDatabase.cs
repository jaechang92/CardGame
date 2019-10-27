using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour {


    public List<Card> cardList = new List<Card>();

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
