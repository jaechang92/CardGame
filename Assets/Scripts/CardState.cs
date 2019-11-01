using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardState : MonoBehaviour {

    public List<Sprite> sprites;

    public float ratio;

    public int mana;
    public int damage;
    public int hp;

    public Image image;
    private RectTransform tr;
    void Awake()
    {
        
    }

    void Start () {
        ratio = 134.0f / 200.0f;

        tr = GetComponent<RectTransform>();
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        tr.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tr.sizeDelta.x/ratio);
        
        
        if (tr.eulerAngles.y > 90 && tr.eulerAngles.y <= 180)
        {

            image.sprite = sprites[0];
        }
        else
        {

            image.sprite = sprites[1];
        }
    }

    public void CardSetup(int CardID)
    {

    }
}
