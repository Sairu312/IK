using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootSetUp : MonoBehaviour
{
    public RootMaster rootMasterScript;
    public GameObject bornObject;
    public GameObject targetObject;
    public GameObject tipObject;
    Transform rootTransform;
    public int boonNum;

    // Start is called before the first frame update
    void Start()
    {
        rootTransform = transform;
        for(int i = 0; i < boonNum; i++)
        {
            MakeBone(rootTransform);
        }
        MakeTip(rootTransform);
    }

    

    void MakeBone(Transform parentTransform)
    {
        GameObject obj = (GameObject)Instantiate(bornObject,Vector3.zero,Quaternion.Euler(Vector3.zero));
        obj.transform.parent = parentTransform;
        obj.transform.localPosition = new Vector3(0, 0, 2);
        rootTransform = obj.transform;
    }

    void MakeTip(Transform parentTransform)
    {
        GameObject obj = (GameObject)Instantiate(tipObject);
        obj.name = "Tip";
        obj.transform.parent = parentTransform;
        obj.transform.localPosition = new Vector3(0, 0, 2);
    }
}
