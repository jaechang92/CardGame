using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    static public ObjectPool instance;
    public int maxCount;

    public List<GameObject> CardDec;
    public List<GameObject> EmptyDec;

    public GameObject nullDec;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.transform.root.gameObject);
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {


    }
	

    public GameObject PoolObj()
    {
        if (EmptyDec.Count > 0)
        {
            GameObject obj = EmptyDec[EmptyDec.Count-1];
            EmptyDec.Remove(obj);
            CardDec.Add(obj);
            return obj;
        }
        else
        {
            return null;
        }
    }


    public void PushObj(GameObject obj)
    {
        EmptyDec.Add(obj);
        obj.transform.SetParent(this.gameObject.transform);
        obj.transform.position = this.gameObject.transform.position;
        CardDec.Remove(obj);
        Debug.Log("push");
    }



}
