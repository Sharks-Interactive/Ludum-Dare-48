using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SharkUtils;

public class HorseNoises : MonoBehaviour
{
    public List<AudioClip> HorseNoisesL = new List<AudioClip>();
    public AudioSource Player;
    public Vector2 TimeRange;
    public GameObject Darkness;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Play());
    }

    // Update is called once per frame
    public IEnumerator Play()
    {
        yield return new WaitForSeconds(ExtraFunctions.RandomFromRange(TimeRange));

        if (Darkness.activeInHierarchy)
            Player.PlayOneShot(ExtraFunctions.RandomFromList(HorseNoisesL));
        StartCoroutine(Play());
    }
}
