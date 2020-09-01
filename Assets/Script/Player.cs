using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class Player : AttackManger
{
    public float speed;
    public int playerID;

    private Animator animator;

    private bool isMove = true;

    private static readonly Joycon.Button[] m_buttons =
      Enum.GetValues(typeof(Joycon.Button)) as Joycon.Button[];

    private List<Joycon> m_joycons;
    private Joycon m_joyconL;
    private Joycon m_joyconR;
    private Joycon.Button? m_pressedButtonL;
    private Joycon.Button? m_pressedButtonR;


    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();

        m_joycons = JoyconManager.Instance.j;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        //m_joyconL = m_joycons.Find(c => c.isLeft);
        //m_joyconR = m_joycons.Find(c => !c.isLeft);
        //m_joycons[0] = m_joyconL;
        //m_joycons[1] = m_joyconR;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove == true)
        {
            PlayerMove();
            if (StartGame.isStart == true)
            {
                if (Input.GetKeyDown(KeyCode.Space) | m_joycons[playerID].GetButtonDown(m_buttons[0]))
                {
                    animator.SetTrigger("Attack");
                    this.animator.SetBool("IsWalk", false);
                    AttackAnimetion();
                    base.PlayerAttack(playerID);
                }
            }
        }
    }

    //移動
    public void PlayerMove()
    {
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");
        //joycon
        var stick = m_joycons[playerID].GetStick();
        dx = stick[0];
        dz = stick[1];
        //joycon調整
        if (playerID % 2 == 0)
        {
            dz = -1 * dz;
        }
        else
        {
            dx = -1 * dx;
        }
        //向き
        transform.LookAt(new Vector3(transform.position.x + dz, transform.position.y, transform.position.z + dx));
        //移動
        if (dx != 0 || dz != 0)
        {
            this.animator.SetBool("IsWalk", true);
            this.transform.position = this.transform.position + transform.forward * speed;
        }
        else
        {
            this.animator.SetBool("IsWalk", false);
        }

    }
    //攻撃アクション時間
    private void AttackAnimetion()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float AttackIntervalTime = stateInfo.length;
        StartCoroutine(AttackInterval(AttackIntervalTime - 0.4f));
    }

    IEnumerator AttackInterval(float AttackIntervalTime)
    {
        isMove = false;
        yield return new WaitForSeconds(AttackIntervalTime);
        isMove = true;
    }

}
