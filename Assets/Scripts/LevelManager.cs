using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public Image Transition;

    [Space(10)]
    public bool AdvanceLevelTrigger;
    public int TestingLevel;

    //Cache
    public int _currentLevel = 0;
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

    void Start() => StartUp();

    public void StartUp ()
    {
        _currentLevel = PlayerPrefs.GetInt("Level", 0);
#if UNITY_EDITOR
        _currentLevel = TestingLevel;
#endif
        Player.transform.position = LevelOrigins[_currentLevel].position;
        Cam.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
    }

    public void ResetLevel()
    {
        if (_cr != null)
            return;

        //_currentLevel--;
        PlayerPrefs.SetInt("Level", _currentLevel);
        Transition.color = Color.red;
        TransitionAnim.SetTrigger("Fade");
        _cr = StartCoroutine(YesImReallySerious());
    }

    public void AdvanceLevel()
    {
        if (_cr != null)
            return;

        _currentLevel++;
        Transition.color = Color.black;
        TransitionAnim.SetTrigger("Fade");
        _cr = StartCoroutine(YesImSerious());
    }

    public IEnumerator YesImSerious ()
    {
        yield return new WaitForSeconds(0.9f);
        Player.transform.position = LevelOrigins[_currentLevel].position;
        Cam.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
        _cr = null;
    }

    public IEnumerator YesImReallySerious()
    {
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(1);
        _cr = null;
    }
}
