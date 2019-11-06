using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PressEvent : MonoBehaviour ,IPointerDownHandler,IPointerUpHandler{

    public float currentTime = 0;
    public float pressTime;
    public bool isPress = false;

    
    public void OnPointerDown(PointerEventData eventData)
    {
        currentTime = 0;
        isPress = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPress = false;
    }


        // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isPress)
        {
            currentTime += Time.deltaTime;

            if (currentTime > pressTime)
            {
                this.gameObject.transform.parent.parent.GetComponent<ScrollRect>().vertical = false;
            }
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            isPress = false;
            this.gameObject.transform.parent.parent.GetComponent<ScrollRect>().vertical = true;
        }

    }
}
