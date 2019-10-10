using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 最も親の関節に使用するスクリプト
 * 子供に使用するスクリプトとの違いは親を決めるかどうか
 * 正直それぐらいで別のスクリプトを書くのはバカバカしいが
 * どちらが良いかわからないのと，時短のためということにしておく
 * 終わった
 */

    /*ではこのIKをどの方向に持っていくべきか
     * 各ボーンを伸ばす方向はオブジェクトの形を変える必要がある
     * 最初は難しい話かと思ったが，そもそもUnity側でサイズをかえるだけかもしれない．
     * 優先順位は低いがやってもいいだろう
     *
     * 次は関節の可動制限だ．これは普通のIKシステムなら標準搭載だからやるべきことかもしれない
     * しかし，今の所必要性を感じていない．どのIKでも使用されている機能ならばそのうち必要ななるだろう
     *
     * やりたいことはFIKシステム．それとゲームづくり．
     * ゲームづくりは正直なにも構想が無いと言っても良い．
     * ここで言う構想とは製作過程のことだ，どの様なゲームをつくるかは決まっているがそれを完成させるための過程が想定できない．
     *
     * メインはFIKとKH移動システム．KHは確認して使用と流用ができるか確認を
     * 人のモデルとアニメーションアクションゲームの流れをどの様につくるか
     */


public class RootMaster : MonoBehaviour
{
    //public GameObject childObject;
    public GameObject targetObject;
    public GameObject tipObject;
    //public Vector3 MaxLimit;
    //public Vector3 MinLimit;
    float timeCount;
    public bool flag;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        IKRotation();
    }

    void Setup()
    {
        //childObject = transform.GetChild(1).gameObject;
        targetObject = GameObject.Find("Target");
        tipObject = GameObject.Find("Tip");
        timeCount = 0.0f;
    }

    void IKRotation()//関節と先端から関節とターゲットまでの回転を取得して回転させる．これを各関節に使用することでIKとして働く．
    {
        if(tipObject == null) tipObject = GameObject.Find("Tip");
        var qTarget = Quaternion.LookRotation(targetObject.transform.position - transform.position);
        var qTip = Quaternion.LookRotation(tipObject.transform.position - transform.position);
        var qTargetToTip = qTarget * Quaternion.Inverse(qTip);
        var qRoot = qTargetToTip * transform.rotation;
        /*
         * これは最初のアルゴリズム．正方向には調子が良いが負に行くとゲッタン
         * 直った
         */
        //var qRoot = transform.rotation * qTargetToTip;
        /*
        Debug.Log("MaxQ:" + MaxLimit);
        Debug.Log("MinQ:" + MinLimit);
        Debug.Log("qRoot:" + qRoot.eulerAngles);

        if ((MaxLimit.x > qRoot.eulerAngles.x ||
            360 + MinLimit.x < qRoot.eulerAngles.x) &&
            (MaxLimit.y > qRoot.eulerAngles.y ||
            360 + MinLimit.y < qRoot.eulerAngles.y )&&
            (MaxLimit.z > qRoot.eulerAngles.z ||
             360 + MinLimit.z < qRoot.eulerAngles.z) 
            )
        {
        */
        if (flag)
        {
            Debug.Log("Root:"+qRoot.eulerAngles);
            Debug.Log("Parent:"+transform.parent.rotation.eulerAngles);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation,qRoot,timeCount);
        timeCount += Time.deltaTime;
        //};
        
    }


}
