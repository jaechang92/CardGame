using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour , IPointerDownHandler, IPointerUpHandler {

    public void OnPointerDown(PointerEventData eventData)
    {
        startPosition = this.gameObject.transform.position;
        startRotation = this.gameObject.transform.rotation;
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.transform.position);
        if (this.gameObject.transform.position.y >= 180)
        {

        }
        else
        {
            this.gameObject.transform.position = startPosition;
            this.gameObject.transform.rotation = startRotation;
        }
        isDragging = false;
    }

    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool isDragging = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isDragging)
        {
            this.gameObject.transform.position = Input.mousePosition;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
		
	}
}
