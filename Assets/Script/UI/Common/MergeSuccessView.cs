using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeSuccessView : MonoBehaviour
{
    public static MergeSuccessView Instance;
    
    public Animator anim;
    public List<CardBagViewController> cardBagViews;
    public GameObject cardPrefab;
    public Transform cardRoot;

    private MergeSuccessCard card;
    private CardData cardData;

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

    private void Start()
    {
        MessageCenter.Instance.RegisterListner(MessageType.CardMergeSuccess, OnCardMergeSuccess);
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        MessageCenter.Instance.UnRegisterListner(MessageType.CardMergeSuccess, OnCardMergeSuccess);
    }

    private void OnCardMergeSuccess(MessageBase messageBase)
    {
        CardMergeSuccessMessage msg = (CardMergeSuccessMessage)messageBase;
        cardData = msg.card;
        GameObject obj = Instantiate(cardPrefab, cardRoot);
        card = obj.GetComponent<MergeSuccessCard>();
        Sprite sprite = CardConfig.Instance.GetCardImageByCode(msg.card.code);
        card.cardImage.sprite = sprite;
        card.cardImage.SetNativeSize();
        card.transform.localPosition = Vector3.zero;
        gameObject.SetActive(true);
        
    }

    public void OnCollectClick()
    {
        card.transform.SetParent(TipsController.Instance.transform);
        foreach (var view in cardBagViews)
        {
            if (view.gameObject.activeInHierarchy)
            {
                Vector3 pos = view.GetCardPos(cardData);
                card.Fly(pos);
                break;
            }
        }
        gameObject.SetActive(false);
    }
}
