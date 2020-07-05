using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsController : MonoBehaviour
{
    public static TipsController Instance;

    public GameObject tipsGob;
    public Text tipsText;

    private DragItemObjectPair _currentPair;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void ShowTips(string tipsStr, float duration = 2f)
    {
        StartCoroutine(StartShowTips(tipsStr, duration));
    }

    private IEnumerator StartShowTips(string tipsStr,float duration = 2f)
    {
        if (!tipsGob)
        {
            yield break;
        }
        tipsText.text = "";
        yield return null;
        tipsGob.SetActive(true);
        tipsText.text = tipsStr;
        yield return new WaitForSeconds(duration);
        tipsGob.SetActive(false);
    }
}
