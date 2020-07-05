using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMergerViewController : MonoBehaviour
{
    public List<MergeItemView> mergeItemViews;
    private CardMergeBag _bag;
    private void Start()
    {
        _bag = new CardMergeBag(new List<BagItemType>() { BagItemType.Normal_Card }, 3);
        foreach (var view in mergeItemViews)
        {
            view.bag = _bag;
        }
    }

    public void OnMergeButtonClick()
    {
        ICardMergeResult result = _bag.Merge();
        if(result.response == CardMergeResponse.Success)
        {
            CardData card = result.card;
            StartCoroutine(OnSuccess(card));
        }
        else
        {
            TipsController.Instance.ShowTips(result.description);
        }
    }

    private IEnumerator OnSuccess(CardData card)
    {
        foreach (var view in mergeItemViews)
        {
            view.OnMergeSuccess();
        }
        MessageCenter.Instance.PostMessage(new BagItemChangeMessage(BagsManager.Instance.normalCardBag));
        yield return null;
        BagsManager.Instance.normalCardBag.AddBagItem(card);
        MessageCenter.Instance.PostMessage(new CardMergeSuccessMessage(card));
    }
}
