using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MergeItemView : MonoBehaviour
{
    public Transform _root;
    public GameObject _buttonGob;
    public CardMergeBag bag;
    public DragItemObjectPair _currentPair;
    

    private void Start()
    {
        DragLayer.Instance.endDraggingItemChangeEvent += OnEndDraggingItemChange;
    }
    private void OnDestroy()
    {
        DragLayer.Instance.endDraggingItemChangeEvent -= OnEndDraggingItemChange;
    }
    private void OnEndDraggingItemChange(DragItemObjectPair pair, PointerEventData eventData)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        foreach (var result in results)
        {
            if(result.gameObject == gameObject)
            {
                if (_currentPair != null)
                {
                    _currentPair.TurnBack();
                }
                _currentPair = pair;
                bag.AddBagItem(_currentPair.item.bagItem);
                _currentPair.item.transform.SetParent(_root);
                _currentPair.item.transform.localPosition = Vector3.zero;
                _currentPair.item.UpdateState(BagGridState.PlaceOtherWhere);
                _buttonGob.SetActive(true);
                break;
            }
        }
    }

    public void TurnBackItem()
    {
        if (_currentPair == null)
        {
            return;
        }
        bag.RemoveBagItem(_currentPair.item.bagItem);
        _currentPair.TurnBack();
        _currentPair.item.UpdateState(BagGridState.Idle);
        _buttonGob.SetActive(false);
        _currentPair = null;
    }

    public void OnMergeSuccess()
    {
        IBagItem card = _currentPair.item.bagItem;
        TurnBackItem();
        BagsManager.Instance.normalCardBag.RemoveBagItem(card);
    }
}
