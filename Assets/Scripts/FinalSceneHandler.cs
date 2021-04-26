using Unity;
using UnityEngine;
using System;

public class FinalSceneHandler : MonoBehaviour {

  [Header("References")]
  public GameObject[] Doors = new GameObject[3];
  public GameObject ExplosionEffects;
  public GameObject GameOverScreenThing;

  [Header("Balance Options")]
  public float[] DoorValueIncrease = new float[3];
  public float[] DoorValueDecrease = new float[3];

  //Cache
  private float[] _doorProgress = new float[3];
  private float _explosionProgress;

  public float HackComputerInput (int t_computerNum)
  {
    _doorProgress[t_computerNum] += (DoorValueIncrease[t_computerNum] * Time.deltaTime);
    _doorProgress[t_computerNum] -= (_doorProgress[t_computerNum] >= 1) ? 0.1f : 0.0f;

    return _doorProgress[t_computerNum];
  }

  void Update ()
  {
    for (int z; z < _doorProgress.Length; z++)
    {
      _doorProgress[z] -= DoorValueDecrease[z] * Time.deltaTime;
      
      GameOverScreenThing.SetActive(_doorProgress[z] <= 0);
    }
  }

}
