using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class LevelManager : MonoBehaviour
{
    #region GROSS SINGLETON IM SORRY

    private static LevelManager _instance;
    public static LevelManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion

    [Header("Data")]
    public List<Transform> LevelOrigins = new List<Transform>();

    [Header("References")]
    public GameObject Player;
    public Animator TransitionAnim;
    public GameObject Cam;

    [Space(10)]
    public bool AdvanceLevelTrigger;
    public int TestingLevel;

    //Cache
    private int _currentLevel = 0;
    private Coroutine _cr;

#if UNITY_EDITOR
    public void OnValidate()
    {
        _currentLevel = TestingLevel;
        if (AdvanceLevelTrigger)
        {
            AdvanceLevelTrigger = false;
            AdvanceLevel();
        }
    }
#endif

    public void AdvanceLevel()
    {
        if (_cr != null)
            return;

        _currentLevel++;
        TransitionAnim.SetTrigger("Fade");
        _cr = StartCoroutine(YesImSerious());
    }

    public IEnumerator YesImSerious ()
    {
        yield return new WaitForSeconds(0.9f);
        Player.transform.position = LevelOrigins[_currentLevel].position;
        Cam.transform.position = Player.transform.position;
        _cr = null;
    }
}
