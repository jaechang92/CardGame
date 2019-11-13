using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardNameAndOption : MonoBehaviour {

    public RectTransform tr;
    public Image sprite;

    public Vector2 sizeVertical;
    public Vector2 sizeHorizontal;
    // Use this for initialization

    
    public bool switching = false;
    void init()
    {
        tr = GetComponent<RectTransform>();
        sizeVertical = new Vector2(134, 200);
        sizeHorizontal = new Vector2(150, 20);
        sprite = this.gameObject.GetComponent<Image>();
        tr.sizeDelta = sizeVertical;
        
    }

	void Start () {
        init();
    }
	
	// Update is called once per frame
	void Update () {
        if (tr.anchoredPosition.x > 255 && !switching)
        {
            Debug.Log("실행");
            switching = !switching;
            tr.sizeDelta = sizeHorizontal;
            Debug.Log(switching);
        }
        else if(tr.anchoredPosition.x < 255 && switching)
        {
            Debug.Log("실행2");
            switching = !switching;
            tr.sizeDelta = sizeVertical; 
        }

        
	}

    public void GetProperty(Sprite _sprite)
    {
        sprite.sprite =_sprite;
    }

}
