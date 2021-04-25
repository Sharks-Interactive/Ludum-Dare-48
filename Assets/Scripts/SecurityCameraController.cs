using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using SharkUtils;

public class SecurityCameraController : MonoBehaviour
{
    [Header("Settings")]
    public float Speed;
    public float StartRot, EndRot;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, StartRot);
        transform.DORotate(new Vector3(0, 0, EndRot), Speed)
           .SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
