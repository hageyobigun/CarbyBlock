using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FallBlockInterval());
    }

    //落ちる間隔
    IEnumerator FallBlockInterval()
    {
        //落下開始までのインターバル
        yield return new WaitForSeconds(0.5f);
        FallBlockMove();
    }

    //ブロックの落ち方
    public void FallBlockMove()
    {
        this.transform.position += new Vector3(0f, 100f, 0f);
        this.gameObject.AddComponent<ResetBlock>();
        Destroy(this);   
    }
}
