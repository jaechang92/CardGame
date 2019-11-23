using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PressEvent : MonoBehaviour ,IPointerDownHandler,IPointerUpHandler{

    public float currentTime = 0;
    public float pressTime;
    public bool isPress = false;
    public GameObject mask;
    private CardState thisGameObject;
    private RectTransform tr;
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
        thisGameObject = this.gameObject.GetComponent<CardState>();
        tr = GetComponent<RectTransform>();

    }
	
	// Update is called once per frame
	void Update () {

        if (isPress)
        {
            currentTime += Time.deltaTime;

            if (currentTime > pressTime && !UIManager.instance.dragging)
            {
                mask.GetComponent<ScrollRect>().vertical = false;
                UIManager.instance.dragging = true;
                UIManager.instance.StartDragDec(thisGameObject.sprites[0], thisGameObject.sprites[2]);
                ObjectPool.instance.PushObj(gameObject);
            }
        }

        if (Input.GetMouseButtonUp(0) && currentTime > pressTime)
        {
            isPress = false;
            UIManager.instance.dragging = false;
            mask.GetComponent<ScrollRect>().vertical = true;
            
        }

    }
}
