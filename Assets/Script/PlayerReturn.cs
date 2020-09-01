using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReturn : MonoBehaviour
{
	private float InvincibleTime;
    private float IntervalTime = 0; //点滅周期
    public float Life;

    private bool isReturn;

    public Text IDtext;

    public GameObject MeshChild;
    public GameObject FaceMesh;

    Rigidbody rb;

	// Start is called before the first frame update
	void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReturn == true)
        {
            //無敵時間
            InvincibleTime += Time.deltaTime;

            //点滅周期
            IntervalTime += Time.deltaTime;

            if (IntervalTime > 0.1)
            {
                Flashing();
            }

            if (InvincibleTime >= 3)
            {
                FinishInvincible();
            }
        }
        LifeCount();
    }

    ////無敵時間中の点滅
    private void Flashing()
    {
        foreach (Transform child in MeshChild.transform)
        {
            child.gameObject.GetComponent<SkinnedMeshRenderer>().enabled =
                !child.gameObject.GetComponent<SkinnedMeshRenderer>().enabled;
        }
        FaceMesh.GetComponent<SkinnedMeshRenderer>().enabled =
            !FaceMesh.GetComponent<SkinnedMeshRenderer>().enabled;

        IntervalTime = 0;
    }

    //無敵終了
    private void FinishInvincible()
    {
        //無敵終了
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        //無敵時間中の点滅終了
        foreach (Transform child in MeshChild.transform)
        {
            child.gameObject.GetComponent<SkinnedMeshRenderer>().enabled = true;
        }
        FaceMesh.GetComponent<SkinnedMeshRenderer>().enabled = true;

        isReturn = false;
        InvincibleTime = 0;
    }

    //残機
    private void LifeCount()
    {
        //落ちたとき
        if (this.transform.position.y < 0 && GetComponent<Player>().enabled == true)
        {
            Life--;
            GetComponent<Player>().enabled = false;
            StartCoroutine(ReturnInterval());
        }

    }

    //復活までのインターバル
    IEnumerator ReturnInterval()
    {
        yield return new WaitForSeconds(4f);
        //０になったら終了
        if (Life == 0)
        {
            PlayerCount.PlayerNum--;
            IDtext.GetComponent<PlayerUI>().enabled = false;
            Destroy(IDtext);
            Destroy(this.gameObject);
        }
        //復帰
        isReturn = true;
        //無敵
        this.transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        rb.constraints = RigidbodyConstraints.FreezePositionY |
                         RigidbodyConstraints.FreezeRotation;
        GetComponent<Player>().enabled = true;
    }
}
