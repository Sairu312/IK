using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornScript : MonoBehaviour
{

    public GameObject parentObject;
    public GameObject childObject;
    // Start is called before the first frame update
    void Start()
    {
        parentObject = transform.parent.gameObject;
        childObject = transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
