using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState : MonoBehaviour {

    public float ratio;

    public int mana;
    public int damage;
    public int hp;

    private RectTransform tr;
    void Awake()
    {
        
    }

    void Start () {
        ratio = 134.0f / 200.0f;
        Debug.Log(ratio);
        tr = GetComponent<RectTransform>();
        
	}
	
	// Update is called once per frame
	void Update () {
        tr.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tr.sizeDelta.x/ratio);
    }

    public void CardSetup(int CardID)
    {

    }
}
