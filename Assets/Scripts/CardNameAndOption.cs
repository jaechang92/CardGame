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

    
    public bool OnDec = false;
    public Sprite[] sprites;
    public Sprite nullsprite;
    void init()
    {
        tr = GetComponent<RectTransform>();
        sizeVertical = new Vector2(134, 200);
        sizeHorizontal = new Vector2(150, 20);
        sprite = this.gameObject.GetComponent<Image>();
        tr.sizeDelta = sizeVertical;
        sprites = new Sprite[2];


    }

    void Awake()
    {
        init();
    }

	void Start () {
        //init();
    }

    //void OnEnable()
    //{
    //    if (tr.anchoredPosition.x > 255)
    //    {
    //        sprite.sprite = sprites[1];
    //        Debug.Log("실행3");

    //        Debug.Log(tr.anchoredPosition.x);
    //        tr.sizeDelta = sizeHorizontal;

    //    }
    //    else if (tr.anchoredPosition.x < 255)
    //    {
    //        sprite.sprite = sprites[0];
    //        Debug.Log("실행4");

    //        tr.sizeDelta = sizeVertical;
    //    }
    //}


    void OnDisable()
    {
        sprite.sprite = nullsprite;
    }

    // Update is called once per frame
    void Update () {


        if (tr.anchoredPosition.x < 255)
        {
            OnDec = false;
            sprite.sprite = sprites[0];
            //Debug.Log("실행");
            tr.sizeDelta = sizeVertical;
            
        }
        else if(tr.anchoredPosition.x > 255)
        {
            OnDec = true;
            sprite.sprite = sprites[1];
            //Debug.Log("실행2");
            tr.sizeDelta = sizeHorizontal;
        }

        
	}

    public void GetProperty(Sprite _sprite, Sprite _slot)
    {
        //sprite.sprite = _sprite;
        sprites[0] = _sprite;
        sprites[1] = _slot;
    }

}
