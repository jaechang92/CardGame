using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardNameAndOption : MonoBehaviour {

    public RectTransform tr;


    public Vector2 sizeVertical;
    public Vector2 sizeHorizontal;
	// Use this for initialization
	void Start () {
        tr = GetComponent<RectTransform>();
        sizeVertical = new Vector2(134, 200);
        sizeHorizontal = new Vector2(150, 20);
    }
	
	// Update is called once per frame
	void Update () {
        if (tr.anchoredPosition.x > 255)
        {
            tr.sizeDelta = sizeHorizontal;
        }
        else
        {
            tr.sizeDelta = sizeVertical;
        }
	}
}
