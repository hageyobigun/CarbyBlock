using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBlock : MonoBehaviour
{
    [SerializeField] private Transform BlockPlace;
    public GameObject Block;
    public GameObject Wall;

    public static GameObject [,] stage = new GameObject[9,9];

   public static int[,] BlockNumber = new int[10, 10];

    // Start is called before the first frame update
    void Start()
    {
        StageInstance();
    }

    //ステージ生成
    public void StageInstance() 
    {
        for(int x = 0; x < 10; x++){
            for(int z = 0;z < 10; z++) 
            {
                if (x == 0 || x == 9 || z == 9 || z == 0)
                {
                    BlockNumber[x, z] = 0;
                    GameObject wallBlock = Instantiate(Wall, new Vector3(x, 1f, z), Quaternion.identity);
                    wallBlock.transform.SetParent(BlockPlace, false);
                }
                else
                {
                    BlockNumber[x, z] = 1;
                    stage[x, z] = Instantiate(Block, new Vector3(x, 0f, z), Quaternion.identity);
                    stage[x, z].transform.SetParent(BlockPlace, false);
                }
            }
        }
    }

}
