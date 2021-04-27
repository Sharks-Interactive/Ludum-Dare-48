using Unity;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public class FinalSceneHandler : MonoBehaviour 
{
    [Header("References")]
    public GameObject ExplosionEffects;
    public GameObject GameOverScreenThing;
    public Image[] DoorObjects = new Image[6];
    public Image OverallSlider;
    public CanvasGroup OverallSliderCG;
  
    [Header("Balance Options")]
    public float[] DoorValueIncrease = new float[3];
    public float[] DoorValueDecrease = new float[3];
    public float HackTime = 30;

    //Cache
    public float[] _doorProgress = new float[3];
    private float _explosionProgress;
    private bool _hacking;

    public float HackComputerInput (int t_computerNum)
    {
        _doorProgress[t_computerNum] += (DoorValueIncrease[t_computerNum] * Time.deltaTime);
        _doorProgress[t_computerNum] = (_doorProgress[t_computerNum] >= 1) ? 1.0f : _doorProgress[t_computerNum];

        return _doorProgress[t_computerNum];
    }

    public void StartHacking () => StartCoroutine(HackFacility()); 
  
    public IEnumerator HackFacility ()
    {
        _hacking = true;
        OverallSliderCG.alpha = 1.0f;
        yield return new WaitForSeconds(0.2f);
        OverallSlider.fillAmount = HackTime / 30;
        HackTime -= 0.2f;
    
        if (HackTime <= 0)
        {
            ExplosionEffects.SetActive(true);
            Time.timeScale = 0.0f;
            yield return null;
        }
    
        StartCoroutine(HackFacility());
    }
  
    void Update ()
    {
        if (!_hacking) return;

        for (int z = 0; z < _doorProgress.Length; z++)
        {
            if (_doorProgress[z] <= 0) break;
            _doorProgress[z] -= UnityEngine.Random.Range(0.025f * Time.deltaTime, DoorValueDecrease[z] * Time.deltaTime);
            DoorObjects[z].fillAmount = _doorProgress[z];
            DoorObjects[z + 3].fillAmount = _doorProgress[z];
            
            if (_doorProgress[z] <= 0) LevelManager.Instance.ResetLevel();
        }
    }
}
