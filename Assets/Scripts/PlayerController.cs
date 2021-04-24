using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SharkUtils;

public class PlayerController : MonoBehaviour
{
    public Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0.5f * Time.deltaTime, 0, 0);
        }

        LookTowardsMouse();
    }

    public void LookTowardsMouse()
    {
        Vector3 lookAtTargetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Quaternion rot = Quaternion.LookRotation(transform.position - lookAtTargetPos, Vector3.forward);
        rot.x = transform.rotation.x;
        rot.y = transform.rotation.y;
        rot.eulerAngles = new Vector3(rot.eulerAngles.x, rot.eulerAngles.y, rot.eulerAngles.z + 90);

        transform.rotation = rot;
    }
}
