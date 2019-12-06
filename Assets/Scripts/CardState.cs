using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardState : MonoBehaviour
{

    public int ID;
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

    void Start()
    {
        ratio = 134.0f / 200.0f;

        tr = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log((-180 <= tr.eulerAngles.y && tr.eulerAngles.y <= -90));
        
        if (this.gameObject.tag == "Card" || this.gameObject.tag == "FieldCard")
        {
            tr.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tr.sizeDelta.x / ratio);
            // 90 <= X <= 180 && -180 <= X <= -90 까진 뒷면 나머지는 앞면
            if (tr.eulerAngles.y >= 90 && tr.eulerAngles.y <= 270)
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
        ID = CardID;
        mana = CardDatabase.instance.cardList[CardID].mana;
        damage = CardDatabase.instance.cardList[CardID].damage;
        hp = CardDatabase.instance.cardList[CardID].hp;
        sprites[0] = (CardDatabase.instance.cardList[CardID].cardIcon);
        sprites[1] = (CardDatabase.instance.backIcon);
        sprites[2] = (CardDatabase.instance.cardList[CardID].cardSlotIcon);

    }

    public void CardSetup(CardState CardObject)
    {
        ID = CardObject.ID;
        mana = CardObject.mana;
        damage = CardObject.damage;
        hp = CardObject.hp;
        sprites[0] = (CardObject.sprites[0]);
        sprites[1] = (CardObject.sprites[1]);
        sprites[2] = (CardObject.sprites[2]);
    }
}
