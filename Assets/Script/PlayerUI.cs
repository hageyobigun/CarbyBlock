using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Transform targetTfm;

    private RectTransform myRectTfm;
    private Vector3 offset = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        myRectTfm = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        myRectTfm.position 
            = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTfm.position + offset);
    }
}
