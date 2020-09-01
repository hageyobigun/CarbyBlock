using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResetBlock : MonoBehaviour
{
    public GameObject Block;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ResetInterval());
    }

    //復活インターバル
    IEnumerator ResetInterval()
    {
        yield return new WaitForSeconds(4f);
        InstanceFallBlock();     
    }

    //ブロック復活
    public void InstanceFallBlock()
    {
        int x =Convert.ToInt32(this.transform.position.x);
        int z = Convert.ToInt32(this.transform.position.z);

        StageBlock.stage[x, z].GetComponentInChildren<Renderer>().material.color = Color.white;

        this.transform.position = new Vector3(x, 0f, z);

        //戻す
        StageBlock.BlockNumber[x, z] = 1;

        Destroy(this);
    }
}
