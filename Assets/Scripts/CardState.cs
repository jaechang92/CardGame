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

        if (this.gameObject.tag == "Card")
        {
            tr.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tr.sizeDelta.x / ratio);
            if (tr.eulerAngles.y > 90 && tr.eulerAngles.y <= 180)
            {

                image.sprite = sprites[1];
            }
            else
            {

                image.sprite = sprites[0];
            }
        }
        else
        {
            if (sprites[2] != null)
            {
                image.sprite = sprites[2];
            }
        }
    }

    public void CardSetup(int CardID)
    {
        mana = CardDatabase.instance.cardList[CardID].mana;
        damage = CardDatabase.instance.cardList[CardID].damage;
        hp = CardDatabase.instance.cardList[CardID].hp;
        sprites[0] =(CardDatabase.instance.cardList[CardID].cardIcon);
        sprites[1] = (CardDatabase.instance.backIcon);
        sprites[2] = (CardDatabase.instance.cardList[CardID].cardSlotIcon);

    }
}
