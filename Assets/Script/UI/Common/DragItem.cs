﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DragItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public abstract void OnBeginDrag(PointerEventData eventData);
    public abstract void OnDrag(PointerEventData eventData);
    public abstract void OnEndDrag(PointerEventData eventData);
}
