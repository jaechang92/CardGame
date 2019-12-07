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

        if (this.gameObject.transform.position.y >= 180 && !this.gameObject.CompareTag("FieldCard"))
        {
            //필드에 내놓는다
            Debug.Log("field");
            FieldDrop();
            this.gameObject.tag = "FieldCard";
        }
        else
        {
            this.gameObject.transform.position = startPosition;
            this.gameObject.transform.rotation = startRotation;
        }
        isDragging = false;
    }

    private Animator _animator;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool isDragging = false;
    public bool OnOff = true;
    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        if (isDragging && OnOff)
        {
            //Debug.Log("Drop");
            this.gameObject.transform.position = Input.mousePosition;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
		
	}



    public void FieldDrop()
    {
        this.gameObject.transform.SetParent(GameManager.instance.FieldParent[0].transform);
        GameManager.instance.PlayerField.Add(this.gameObject);
        GameManager.instance.FieldDecGrid.ObjectToSort.Add(this.gameObject);
        GameManager.instance.FieldDecGrid.FieldSort();
        _animator.SetTrigger("Action");
        Debug.Log("in");
        OnOff = false;
    }
}
