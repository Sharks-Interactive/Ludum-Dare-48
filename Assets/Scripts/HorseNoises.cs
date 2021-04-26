using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SharkUtils;

public class HorseNoises : MonoBehaviour
{

    public List<AudioClip> HorseNoises = new List<AudioClip>();
    public AudioSource Player;
    public Vector2 TimeRange;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Play());
    }

    // Update is called once per frame
    IEnumerator Play()
    {
        yield return new WaitForSeconds(2);
    }
}
