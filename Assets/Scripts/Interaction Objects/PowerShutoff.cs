using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerShutoff : MonoBehaviour, IInteractableElement
{
    [TextArea(3, 5)]
    public string InteractionMessage;

    public string InteractionText { get; set; }
    public GameObject PowerOff;
    public GameObject CameraView;
    public Collider2D CameraCollider;
    public Collider2D InteractionBox;
    public GameObject Fog;

    void Start()
    {
        InteractionText = InteractionMessage;
    }

    public void OnInteractionExit()
    {

    }

    public void OnInteractionEnter()
    {

    }

    public void OnInteracted()
    {
        PowerOff.SetActive(true);
        CameraView.SetActive(false);
        CameraCollider.enabled = false;
        InteractionBox.enabled = false;
        Fog.SetActive(true);
    }
}
