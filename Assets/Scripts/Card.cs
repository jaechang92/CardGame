using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public int cardID; // 몬스터의 고유 ID값. 중복 불가능
    public string cardName; // 몬스터의 이름. 중복 가능.
    public string cardDescription; // 몬스터의 설명

    public Sprite cardIcon; // 몬스터의 기본 아이콘.

    //카드는 마나 공격력 생명력 마법효과가 있다.

    public int mana;
    public int damage;
    public int hp;

    public Card(int _cardID, string _cardName, string _cardDescription, Sprite _cardIcon,int _mana,int _damage,int _hp)
    {
        cardID = _cardID;
        cardName = _cardName;
        cardDescription = _cardDescription;
        cardIcon = _cardIcon;
        mana = _mana;
        damage = _damage;
        hp = _hp;
    }

}
