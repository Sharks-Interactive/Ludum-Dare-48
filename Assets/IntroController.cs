using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class IntroController : MonoBehaviour
{
    [TextArea(3, 5)]
    public List<string> DialogLines = new List<string>();
    public TextMeshProUGUI lines;
    public int LineNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        lines.text = DialogLines[LineNum];
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.Instance._currentLevel != 0) Destroy(transform.gameObject);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lines.DOKill();
            lines.DOFade(0.0f, 1.0f);
            LineNum++;
            if (LineNum >= DialogLines.Count)
            {
                GetComponent<CanvasGroup>().DOFade(0.0f, 1.0f);
                Destroy(this);
            }

            StartCoroutine(WaitTillDone());
        }
    }

    public IEnumerator WaitTillDone ()
    {
        yield return new WaitForSeconds(1.0f);
        lines.text = DialogLines[LineNum];
        lines.DOKill();
        lines.DOFade(1.0f, 1.0f);
    }
}
