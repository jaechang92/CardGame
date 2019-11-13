using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDecManager : MonoBehaviour {

    public int maxCount;

    public List<GameObject> CardDec;


    private List<Image> LCD;
    public int pivot = 0;
	void Start () {
        
        foreach (var item in CardDec)
        {
            if( item.GetComponent<Image>().sprite == null)
            {
                item.SetActive(false);
            }
        }
	}
	
	
	void Update () {
		
	}


    public void GetImage(Sprite _sprite)
    {
        CardDec[pivot].SetActive(true);
        CardDec[pivot].GetComponent<Image>().sprite = _sprite;
        pivot++;
    }

}
