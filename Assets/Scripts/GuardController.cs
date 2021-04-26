using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController : MonoBehaviour
{
    [Header("Data")]
    public List<Vector3> PathMarkers = new List<Vector3>();
    public float Speed;

    [Header("References")]
    public Animator GuardAnimator;

    //Cache
    private float _lastXPosition;
    private int _currentPathMarker = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GuardAnimator.SetBool("FacingRight", _lastXPosition - transform.position.x < 0);
        _lastXPosition = transform.position.x;

        transform.position = Vector3.MoveTowards(transform.position, PathMarkers[_currentPathMarker], (Speed * 150) * Time.deltaTime);

        if (transform.position == PathMarkers[_currentPathMarker])
            if (_currentPathMarker == PathMarkers.Count - 1)
                _currentPathMarker = 0;
            else
                _currentPathMarker++;
    }

    public void InvestigateDisturbance(string LocalPos)
    {
        string[] _positionsList = LocalPos.Split('|');
        List<float> _positions = new List<float>();

        for (int x = 0; x < PathMarkers.Count; x++)
        {
            PathMarkers[x] = new Vector3(float.Parse(_positionsList[0]), float.Parse(_positionsList[1]), float.Parse(_positionsList[2]));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("GuardBlock"))
            return;

        if (_currentPathMarker != 0)
            _currentPathMarker--;
        else
            _currentPathMarker = PathMarkers.Count - 1;
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        for (int i = 0; i < PathMarkers.Count; i++)
        {
            if (i > 0)
                Gizmos.DrawLine(PathMarkers[i - 1], PathMarkers[i]);

            transform.position = PathMarkers[0];
            Gizmos.DrawCube(PathMarkers[i], new Vector3(1, 1, 1));

            if (i == PathMarkers.Count - 1 && i > 0)
                Gizmos.DrawLine(PathMarkers[i], PathMarkers[0]);
        }
    }

#endif
}
