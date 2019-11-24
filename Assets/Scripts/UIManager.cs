using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UIManager : MonoBehaviour{

    static public UIManager instance;
    public List<GameObject> UI;
    public List<GameObject> Page;


    public GameObject cardDrag;
    public bool dragging = false;
    public ScrollRect scrollRect;

    private int temp = 0;
    private CardNameAndOption _cardNameAndOption;
    private CardDecManager CDM;
    private int CardInDex;
    void Init()
    {
        //UI[1].SetActive(false);
        cardDrag.SetActive(false);
        _cardNameAndOption = cardDrag.GetComponent<CardNameAndOption>();
        CDM = GameManager.instance.managerPool[4].GetComponent<CardDecManager>();
    }

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

    // Use this for initialization
    void Start () {
        Init();
    }
	
	// Update is called once per frame
	void Update () {

        if (dragging)
        {
            cardDrag.SetActive(true);
            cardDrag.transform.position = Input.mousePosition;
        }
        else
        {
            if (_cardNameAndOption.OnDec)
            {
                GameObject obj = ObjectPool.instance.PullObj();
                if (obj != null)
                {
                    CDM.GetState(obj,_cardNameAndOption.sprite.sprite, CardInDex);
                    obj.GetComponentInChildren<Text>().text = CardDatabase.instance.cardList[CardInDex].cardName.ToString();
                }
                else
                {
                    Debug.Log("더이상 추가할수 없습니다.");
                }
                Debug.Log("드롭");
                _cardNameAndOption.OnDec = false;

            }
            cardDrag.SetActive(false);
        }




	}


    public void SelectBtn()
    {
        UI[0].SetActive(false);
        UI[1].SetActive(true);
    }

    public void SelectCardSlotBtn()
    {

    }


    public void CardSelectArrowButton(string A)
    {
        
        switch (A)
        {
            case "Right":
                //Debug.Log(EventSystem.current.currentSelectedGameObject.transform.parent.name);
                EventSystem.current.currentSelectedGameObject.transform.parent.GetComponent<Animator>().SetTrigger("Close");
                break;

            case "Left":
                
                temp = int.Parse(EventSystem.current.currentSelectedGameObject.transform.parent.name);
                Page[temp-1].GetComponent<Animator>().SetTrigger("Open");
                
                break;

            default:
                break;
        }
    }
    


    public void StartDrag(int i)
    {
        dragging = true;
        _cardNameAndOption.GetProperty(CardDatabase.instance.cardList[i].cardIcon, CardDatabase.instance.cardList[i].cardSlotIcon);
        _cardNameAndOption.cardName = CardDatabase.instance.cardList[i].cardName.ToString();
        CardInDex = i;
    }

    public void EndDrag()
    {
        dragging = false;
        scrollRect.vertical = true;
        Debug.Log("EndDrag");
    }

    public void StartDragDec(Sprite s1, Sprite s2)
    {
        dragging = true;
        _cardNameAndOption.GetProperty(s1, s2);
        Debug.Log("StartDragDec");
        
    }

    public void TestBtn()
    {
        Debug.Log("Click");
    }


    public void BackSpace()
    {
        EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
    }

    public void GoToMenuBtn(GameObject obj)
    {
        obj.SetActive(true);
    }

}
