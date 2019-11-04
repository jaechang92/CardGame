using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {

    public List<GameObject> UI;

	// Use this for initialization
	void Start () {
        UI[1].SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
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
                EventSystem.current.currentSelectedGameObject.transform.parent.GetComponent<Animator>().SetTrigger("Open");
                break;

            default:
                break;
        }
    }
    

}
