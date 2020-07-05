using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Networking;

public enum BagGridState
{
    Empty = 1,
    PlaceOtherWhere = 2,
    Dragging = 3,
    Idle = 4,
}

public class BagGrid : MonoBehaviour 
{
    public BagItemView bagItemView;

    public void UpdateState( BagGridState state)
    {
        if (bagItemView)
        {
            bagItemView.UpdateState(state);
        }
    }
}
