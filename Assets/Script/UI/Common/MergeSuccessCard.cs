using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeSuccessCard : MonoBehaviour
{
    public float duration = 2f;

    public Image cardImage;
    public GameObject light;

    public void Fly(Vector3 pos)
    {
        StartCoroutine(FlyToPos(pos));
    }
    [ContextMenu("fly")]
    public void Fly()
    {
        StartCoroutine(FlyToPos(Vector3.zero));
    }



    private IEnumerator FlyToPos(Vector3 pos)
    {
        Vector3 startPos = transform.position;
        float distance = (pos - startPos).magnitude;
        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, pos, timer/ duration);
            transform.localScale = Vector3.one * (duration - timer);
            yield return null;
        }
        cardImage.enabled = false;
        transform.localScale = Vector3.one;
        light.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        MessageCenter.Instance.PostMessage(new BagItemChangeMessage(BagsManager.Instance.normalCardBag));
        Destroy(gameObject);
    }
}
