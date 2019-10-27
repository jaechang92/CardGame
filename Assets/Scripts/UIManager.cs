using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

}
