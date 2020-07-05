using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class BagItemView : DragItem, IPointerClickHandler
{
    [SerializeField] private Transform _bagItemParent;
    [SerializeField] private Transform _transparentLayer;
    [SerializeField] private Transform _highLightFrame;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _frame;
    [SerializeField] private Image _transparentIcon;

    public int PositionId { get; set; }
    public BagGridState state;
    public bool highLight = false;
    public IBagItem bagItem;

    private Vector3 offset;

    private void Start()
    {
        MessageCenter.Instance.RegisterListner(MessageType.BagItemClick, OnMergableCardClick);
    }
    private void OnDestroy()
    {
        MessageCenter.Instance.UnRegisterListner(MessageType.BagItemClick, OnMergableCardClick);
    }

    private void OnMergableCardClick(MessageBase messageBase)
    {
        BagItemClickMessage msg = (BagItemClickMessage)messageBase;
        highLight = (this == msg.item);
    }
    public override void OnBeginDrag(PointerEventData eventData)
    {
        offset = Input.mousePosition - transform.position;
        DragLayer.Instance.SetDraggingItem(new DragItemObjectPair(this, transform.parent),eventData);
        UpdateState(BagGridState.Dragging);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition - offset;
        UpdateState(BagGridState.Dragging);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        UpdateState(BagGridState.Idle);
        transform.localPosition = Vector3.zero;
        DragLayer.Instance.TurnBackDraggingItem(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        MessageCenter.Instance.PostMessage(new BagItemClickMessage(this));
    }


    public void UpdateState(BagGridState state)
    {
        this.state = state;
        if (_bagItemParent)
        {
            _bagItemParent.gameObject.SetActive(state > BagGridState.Empty);
        }
        if (_transparentLayer)
        {
            _transparentLayer.gameObject.SetActive(state == BagGridState.Dragging);
        }
    }


    //这里是虚函数，时间关系也是写这里了
    public virtual void SetItemView(IBagItem bagItem)
    {
        this.bagItem = bagItem;
        CardData card = (CardData)bagItem;
        if (_icon)
        {
            _icon.sprite = CardConfig.Instance.GetCardImageByCode(card.code);
            _icon.SetNativeSize();
        }
        if (_transparentIcon)
        {
            _transparentIcon.sprite = CardConfig.Instance.GetCardImageByCode(card.code);
            _transparentIcon.SetNativeSize();
        }
        if (_frame)
        {
            Sprite frameSprite = CardConfig.Instance.GetCardFrame(card.level);
            _frame.sprite = frameSprite;
            _frame.SetNativeSize();
            _frame.gameObject.SetActive(frameSprite);
        }
    }

}
