using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractableElement
{
    [TextArea(3, 5)]
    public string InteractionMessage;

    public string InteractionText { get; set; }

    public bool IsLocked = false;
    public AudioClip DoorOpening;

    void Start()
    {
        InteractionText = InteractionMessage;
    }

    public void OnInteractionExit()
    {

    }

    public void OnInteractionEnter()
    {
        if (IsLocked)
            InteractionText = "This door is locked!";
        else
            InteractionText = InteractionMessage;
    }

    public void Unlock()
    {
        IsLocked = false;
        InteractionText = InteractionMessage;
    }

    public void OnInteracted()
    {
        if (IsLocked)
        {
            InteractionText = "This door is locked!";
            return;
        }
        else
            InteractionText = InteractionMessage;

        GetComponent<AudioSource>().PlayOneShot(DoorOpening);
        LevelManager.Instance.AdvanceLevel();
    }
}
