using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBagViewController : MonoBehaviour 
{
    [SerializeField] private Transform _content;
    [SerializeField] private BagItemType _bagItemType;
    [SerializeField] private GameObject _bagItemGridPrefab;
    [SerializeField] private Transform _otherTag;

    private BagBase _bag;
    private List<BagGrid> _grids = new List<BagGrid>();

    private void Start()
    {
        if (_bagItemType == BagItemType.Normal_Card)
        {
            _bag = BagsManager.Instance.normalCardBag;
        }
        if (_bagItemType == BagItemType.Rare_Card)
        {
            _bag = BagsManager.Instance.rareCardBag;
        }
        InitBag();
        RefreshBagItems();
        MessageCenter.Instance.RegisterListner(MessageType.BagItemChange, OnBagItemChange);
    }

    private void OnDestroy()
    {
        MessageCenter.Instance.UnRegisterListner(MessageType.BagItemChange, OnBagItemChange);
    }
    private void InitBag()
    {
        //这里可以用对象池 还是赶时间不做了
        if (_bag == null || _bag.maxItemCount <= 0)
        {
            return;
        }
        _grids.Clear();
        for (int i = 0; i < _bag.maxItemCount; i++)
        {
            GameObject obj = Instantiate(_bagItemGridPrefab, _content);
            RectTransform rect = obj.GetComponent<RectTransform>();
            BagGrid grid = obj.GetComponent<BagGrid>();
            grid.UpdateState(BagGridState.Empty);
            _grids.Add(grid);
        }
    }

    public void RefreshBagItems()
    {
        if (_bag == null || _bag.maxItemCount <= 0)
        {
            return;
        }
        foreach (var grid in _grids)
        {
            grid.UpdateState(BagGridState.Empty);
        }
        int index = 0;
        foreach (var item in _bag.Items)
        {
            if (item != null)
            {
                _grids[index].bagItemView.SetItemView(item);
                _grids[index].UpdateState(BagGridState.Idle);
                index++;
            }
        }
    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }


    private void OnBagItemChange(MessageBase messageBase)
    {
        BagItemChangeMessage msg = (BagItemChangeMessage)messageBase;
        if (msg.bag != _bag)
        {
            return;
        }
        RefreshBagItems();
    }

    public Vector3 GetCardPos(CardData card)
    {
        for (int i = 0; i < _bag.Items.Count; i++)
        {
            if (_bag.Items[i] == card)
            {
                return _grids[i].transform.position;
            }
        }
        return _otherTag.transform.position;
    }
}
