using Unity;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public class FinalSceneHandler : MonoBehaviour {

  [Header("References")]
  public GameObject[] Doors = new GameObject[3];
  public GameObject ExplosionEffects;
  public GameObject GameOverScreenThing;
  public Image[] DoorObjects = new Image[6];
  public Image OverallSlider;
  
  [Header("Balance Options")]
  public float[] DoorValueIncrease = new float[3];
  public float[] DoorValueDecrease = new float[3];
  public float HackTime = 30;

  //Cache
  private float[] _doorProgress = new float[3];
  private float _explosionProgress;

  public float HackComputerInput (int t_computerNum)
  {
    _doorProgress[t_computerNum] += (DoorValueIncrease[t_computerNum] * Time.deltaTime);
    _doorProgress[t_computerNum] -= (_doorProgress[t_computerNum] >= 1) ? 0.1f : 0.0f;

    return _doorProgress[t_computerNum];
  }

  void Start ()
  {
    StartCoroutine(HackFacility()); 
  }
  
  public IEnumerator HackFacility ()
  {
    yield return new WaitForSeconds(0.2f);
    OverallSlider.fillAmount = 1 / HackTime;
    HackTime -= 0.2f;
    
    if (HackTime <= 0)
    {
      ExplosionEffects.SetActive(true);
      yield return null;
    }
    
    StartCoroutine(HackFacility());
  }
  
  void Update ()
  {
    for (int z = 0; z < _doorProgress.Length; z++)
    {
      if (_doorProgress[z] <= 0) break;
      _doorProgress[z] -= DoorValueDecrease[z] * Time.deltaTime;
      DoorObjects[z].fillAmount = _doorProgress[z];
      DoorObjects[z + 3].fillAmount = _doorProgress[z];
      
      GameOverScreenThing.SetActive(_doorProgress[z] <= 0);
    }
  }

}
