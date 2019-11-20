using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDecManager : MonoBehaviour {

    static public CardDecManager instance;

    public int maxCount;

    public List<GameObject> CardDec;


    
    public int pivot = 0;


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
	
	
	void Update () {
		
	}


    public void GetState(GameObject obj, Sprite _sprite, int i)
    {
        obj.GetComponent<Image>().sprite = _sprite;
        obj.GetComponent<CardState>().CardSetup(i);
        obj.transform.parent = this.gameObject.transform;

    }



}
