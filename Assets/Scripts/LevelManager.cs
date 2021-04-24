using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //Cache
    private int _currentLevel = 0;

    public void AdvanceLevel()
    {
        _currentLevel++;
        Player.transform.position = LevelOrigins[_currentLevel].position;
    }
}
