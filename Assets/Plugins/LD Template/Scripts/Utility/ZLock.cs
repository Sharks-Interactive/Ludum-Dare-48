using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Transform/Z Lock")]
public class ZLock : MonoBehaviour
{
    private Vector3 position;

    void Update()
    {
        position = transform.position;
        position.z = 1;

        transform.position = position;
    }
}
