using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCount : MonoBehaviour
{
    public static int PlayerNum = 2;
    private int count = 3;
    private int winPlayerID;
    public Text winText;

    public List<GameObject> playerUI;
    public List<GameObject> playerLifeUI;
    public List<GameObject> players;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤー数調整
        while(count != PlayerNum)
        {
            Destroy(playerUI[count]);
            Destroy(playerLifeUI[count]);
            Destroy(players[count]);
            count--;
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (PlayerNum == 0)
        {
            winPlayerID = GetWinPlayer();
            WinText();
            players[winPlayerID].GetComponent<Player>().enabled = false;
            PlayerNum--;
        }
    }




    //勝ったプレイヤーが誰か
    private int GetWinPlayer()
    {
        for (int i = 0; i < 4; i++)
        {
            if (players[i] != null)
            {
                return i;
            }

        }
        return 0;
    }

    private void WinText()
    {
        if(winPlayerID == 0)
        {
            winText.color = Color.red;
        }
        if (winPlayerID == 1)
        {
            winText.color = Color.blue;
        }
        if (winPlayerID == 2)
        {
            winText.color = Color.green;
        }
        if (winPlayerID == 3)
        {
            winText.color = Color.yellow;
        }
        winText.text = (winPlayerID + 1) + "P WIN";
    }

}