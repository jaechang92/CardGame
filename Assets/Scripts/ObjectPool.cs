using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    static public ObjectPool instance;
    public int maxCount;

    public List<GameObject> CardDec;
    public GameObject nullDec;

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


    }
	

    public GameObject PoolObj()
    {
        if (CardDec.Count > 1)
        {
            GameObject obj = CardDec[CardDec.Count-1];
            CardDec.Remove(obj);
            return obj;
        }
        else
        {
            return null;
        }
    }


    public void PushObj(GameObject obj)
    {
        CardDec.Add(obj);
        obj.transform.parent = this.gameObject.transform;
        obj.transform.position = this.gameObject.transform.position;
    }



}
