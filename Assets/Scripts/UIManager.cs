using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UIManager : MonoBehaviour{

    public List<GameObject> UI;
    public List<GameObject> Page;


    public GameObject cardDrag;
    public bool dragging = false;
    public ScrollRect scrollRect;

    private int temp = 0;
    private CardNameAndOption _cardNameAndOption;
    private CardDecManager CDM;

    void Init()
    {
        UI[1].SetActive(false);
        cardDrag.SetActive(false);
        _cardNameAndOption = cardDrag.GetComponent<CardNameAndOption>();
        CDM = GameManager.instance.managerPool[4].GetComponent<CardDecManager>();
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
            if (_cardNameAndOption.switching && CDM.pivot < 30)
            {
                CDM.GetImage(_cardNameAndOption.sprite.sprite);
                Debug.Log("드롭");
                _cardNameAndOption.switching = false;
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
        _cardNameAndOption.GetProperty(CardDatabase.instance.cardList[i].cardIcon);
        
    }

    public void EndDrag()
    {
        dragging = false;
        scrollRect.vertical = true;
    }

    

    public void TestBtn()
    {
        Debug.Log("Click");
    }

}
