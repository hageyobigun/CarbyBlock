using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    private int PlayerLife = 0;

    public List<Image> PlayerGauge;

    public Image BakcLifeGauge;

    private bool isDead =false;

    public Text ID;

    // Update is called once per frame
    void Update()
    {
        LifeCountUI();
    }

    //残機
    private void LifeCountUI()
    {
        if (this.transform.position.y < 0 && isDead == false)
        {
            PlayerGauge[PlayerLife].color = Color.black;
            PlayerLife++;
            StartCoroutine(DeadTime());
        }

        //死亡
        if (PlayerLife == 5)
        {
            BakcLifeGauge.color = Color.gray;
            ID.color = Color.white;
        }

    }

    IEnumerator DeadTime()
    {
        isDead = true;
        yield return new WaitForSeconds(5f);
        isDead = false;
    }
}
