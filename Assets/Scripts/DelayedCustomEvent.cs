using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedCustomEvent : MonoBehaviour
{

    [Serializable]
    public class CustomEvent : UnityEvent { }

    [SerializeField]
    public CustomEvent m_Event = new CustomEvent();

    public float Delay;
    
    public void InvokeEvent()
    {
        StartCoroutine(WaitToPreformAction());
    }
    
    IEnumerator WaitToPreformAction ()
    {
        yield return new WaitForSeconds(Delay);
        m_Event.Invoke();
    }
}
