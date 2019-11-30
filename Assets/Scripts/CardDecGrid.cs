using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDecGrid : MonoBehaviour {

    public List<GameObject> ObjectToSort;

    private int count;
    private WaitForSeconds waitTime;
    private void Start()
    {
        waitTime = new WaitForSeconds(0.2f);
        ObjectToSort = GameManager.instance.PlayerGetCardPool;

        //StartCoroutine(SortObj());
    }

    void Update () {
        

    }

    //코루틴 -> 카드를 뽑거나 내거나 했을떄로 변경
    public void SortObj()
    {
        
        Debug.Log("실행1");

        count = ObjectToSort.Count;
        int a = count / 2;
        for (int i = 0; i < count; i++)
        {
            Debug.Log("실행2");
            ObjectToSort[i].transform.SetPositionAndRotation(this.gameObject.transform.position - Vector3.right*100*(i-a), Quaternion.Euler(0, 0, (i - a) * 5));
            //ObjectToSort[i].transform.Rotate(0, 0, (i - a) * 2);
            //ObjectToSort[i].transform.eulerAngles.Set(0, 0, (i-a) * 2);
        }
    }
}
