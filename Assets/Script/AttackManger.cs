using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class  AttackManger : MonoBehaviour
{ 
    Vector3 StartFallBlocks;
    Vector3 PlayerForward;
    Rigidbody rb;
    private int ID;
    int x, z;


    public void PlayerAttack(int id)
    {
        //プレイヤー番号
        ID = id;
        AttackDirection();
        StartCoroutine(ChanegColorInterval());
    }

    //色が変わる間隔
    IEnumerator ChanegColorInterval()
    {
        Vector3 ColorChangeBlock = StartFallBlocks;

        while (StageBlock.BlockNumber[Convert.ToInt32(ColorChangeBlock.x), Convert.ToInt32(ColorChangeBlock.z)] != 0)
        {
            x = Convert.ToInt32(ColorChangeBlock.x);
            z = Convert.ToInt32(ColorChangeBlock.z);
            if (StageBlock.BlockNumber[x, z] == 1)
            {
                FallBlockColor();
                StageBlock.stage[x, z].AddComponent<AttackBlock>();
            }
            ColorChangeBlock += PlayerForward;
            yield return new WaitForSeconds(0.05f);
        }
    }

    //落ちるブロックの色変更
    public void FallBlockColor()
    {
        if(ID == 0)
        {
            StageBlock.stage[x, z].GetComponentInChildren<Renderer>().material.color = Color.red;
        }
        if(ID == 1)
        {
            StageBlock.stage[x, z].GetComponentInChildren<Renderer>().material.color = Color.blue;
        }
        if(ID == 2)
        {
            StageBlock.stage[x, z].GetComponentInChildren<Renderer>().material.color = Color.green;
        }
        if(ID == 3)
        {
            StageBlock.stage[x, z].GetComponentInChildren<Renderer>().material.color = Color.yellow;
        }

        StageBlock.BlockNumber[x, z] = 2;
    }


    //落ちる列の方向
    public void AttackDirection()
    {
        PlayerForward = this.transform.forward;
        PlayerForward.x = Convert.ToInt32(PlayerForward.x);
        PlayerForward.z = Convert.ToInt32(PlayerForward.z);

        StartFallBlocks = this.transform.position + transform.forward;
    }

}
