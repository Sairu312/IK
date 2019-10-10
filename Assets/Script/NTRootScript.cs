using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootScript : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject childObject;
    public GameObject targetObject;
    public GameObject tipObject;

    // Start is called before the first frame update
    void Start()
    {
        parentObject = transform.parent.gameObject;
        childObject = transform.GetChild(1).gameObject;
        targetObject = GameObject.Find("Target");
        tipObject = GameObject.Find("Tip");
    }

    // Update is called once per frame
    void Update()
    {
        var qTarget = Quaternion.LookRotation(targetObject.transform.position - transform.position);
        var qTip = Quaternion.LookRotation(tipObject.transform.position - transform.position);
        var qTargetToTip = qTarget * Quaternion.Inverse(qTip);
        var qRoot = qTargetToTip * transform.rotation;
        //var qRoot = transform.rotation * qTargetToTip;
        transform.rotation = qRoot;
    }

}
