using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDecGrid : MonoBehaviour {

    public List<GameObject> ObjectToSort;

    private int count;
    private WaitForSeconds waitTime;
    private Quaternion rot;
    private void Start()
    {
        waitTime = new WaitForSeconds(0.2f);
        rot = this.gameObject.transform.rotation;
        //StartCoroutine(SortObj());
    }

    void Update () {

    }

    //코루틴 -> 카드를 뽑거나 내거나 했을떄로 변경
    public void SortObj()
    {
        // 회전값 적용이 안됨 고쳐야됨
        // 34번째줄
        
        count = GameManager.instance.PlayerGetCardPool.Count;
        int a = count / 2;
        for (int i = 0; i < count; i++)
        {
            Debug.Log("실행1");
            ObjectToSort[i].transform.SetPositionAndRotation(this.gameObject.transform.position - Vector3.right*(i-a), Quaternion.Euler(new Vector3(0, 0, Mathf.Deg2Rad * (i - a) *2)));
      
            //ObjectToSort[i].transform.Rotate(0, 0, (i - a) * 2);
            //ObjectToSort[i].transform.eulerAngles.Set(0, 0, (i-a) * 2);
        }
    }


    public void FieldSort()
    {
        count = GameManager.instance.PlayerField.Count;
        int a = count / 2;
        for (int i = 0; i < count; i++)
        {
            Debug.Log("실행2");
            ObjectToSort[i].transform.SetPositionAndRotation(this.gameObject.transform.position - Vector3.right  * (i - a), Quaternion.Euler(0, 0, 0));
            //ObjectToSort[i].transform.Rotate(0, 0, (i - a) * 2);
            //ObjectToSort[i].transform.eulerAngles.Set(0, 0, (i-a) * 2);
        }
    }

    public void OneSort()
    {
        count = 3;
        int a = count / 2;
        for (int i = 0; i < count; i++)
        {
            Debug.Log("실행2");
            ObjectToSort[i].transform.SetPositionAndRotation(this.gameObject.transform.position - Vector3.right * 2 * (i - a), Quaternion.Euler(0, 0, 0));
            //ObjectToSort[i].transform.Rotate(0, 0, (i - a) * 2);
            //ObjectToSort[i].transform.eulerAngles.Set(0, 0, (i-a) * 2);
        }
    }

}
