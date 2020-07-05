using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItemObjectPair
{
    public BagItemView item;
    public Transform turnBackRoot;
    public DragItemObjectPair(BagItemView item, Transform turnBackRoot)
    {
        this.item = item;
        this.turnBackRoot = turnBackRoot;
    }
    public void TurnBack()
    {
        item.transform.SetParent(turnBackRoot);
        item.transform.localPosition = Vector3.zero;
    }
}
