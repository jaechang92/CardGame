using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.transform.SetPositionAndRotation(this.transform.position, Quaternion.Euler(0, 30, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
