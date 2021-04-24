using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractableElement
{
    [TextArea(3, 5)]
    public string InteractionMessage;

    public string InteractionText { get; set; }

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
        LevelManager.Instance.AdvanceLevel();
    }
}
