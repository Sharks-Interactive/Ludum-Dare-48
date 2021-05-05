using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class Computer : MonoBehaviour, IInteractableElement
{
    [TextArea(3, 5)]
    public string InteractionMessage;

    public string InteractionText { get; set; }

    public FinalSceneHandler FS;
    public bool _isSpecial;
    public int CompNum;

    [Header("UI Components")]
    public CanvasGroup SliderGroup;
    public Image SliderFill;

    [Serializable]
    public class ComputerHacked : UnityEvent { }

    [SerializeField]
    public ComputerHacked m_Hacked = new ComputerHacked();
    public float HackingTime;

    //Cache
    private bool _readyToHack;
    private float _hackingProgress;
    private bool hack_FadeWatcher;

    void Start()
    {
        InteractionText = InteractionMessage;
    }

    public void OnInteractionExit()
    {
        _readyToHack = false;
    }

    public void OnInteractionEnter()
    {
        _readyToHack = true;
        hack_FadeWatcher = false;
    }

    void FixedUpdate ()
    {
        if (!_readyToHack)
        {
            if (!hack_FadeWatcher)
            {
                SliderGroup.DOKill();
                SliderGroup.DOFade(0.0f, 1);
                hack_FadeWatcher = true;
            }
            return;
        }

        if (Input.GetKey(KeyCode.E))
        {
            SliderGroup.DOKill();
            SliderGroup.DOFade(1.0f, 1);
            _hackingProgress += 1.0f / HackingTime;
            if (_isSpecial)
                FS.HackComputerInput(CompNum);
        }
        else
        {
            SliderGroup.DOKill();
            SliderGroup.DOFade(0.0f, 1);
        }

        SliderFill.fillAmount = _hackingProgress;

        if (_hackingProgress >= 1)
        {
            m_Hacked.Invoke();
            _readyToHack = false;
        }
    }

    public void OnInteracted()
    {
        

    }
}
