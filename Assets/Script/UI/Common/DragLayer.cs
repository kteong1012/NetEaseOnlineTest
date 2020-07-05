using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void StartDraggingItemChangeEvent(DragItemObjectPair pair, PointerEventData eventData);
public delegate void EndDraggingItemChangeEvent(DragItemObjectPair pair, PointerEventData eventData);

public class DragLayer : MonoBehaviour
{
    public static DragLayer Instance;
    public event StartDraggingItemChangeEvent startDraggingItemChangeEvent;
    public event EndDraggingItemChangeEvent endDraggingItemChangeEvent;


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

    public void SetDraggingItem(DragItemObjectPair pair,PointerEventData evenData)
    {
        if (pair == null)
        {
            return;
        }
        if (_currentPair != null && _currentPair != pair)
        {
            TurnBackDraggingItem(evenData);
        }
        _currentPair = pair;
        _currentPair.item.transform.SetParent(transform);
        startDraggingItemChangeEvent?.Invoke(pair, evenData);
    }
    public void TurnBackDraggingItem(PointerEventData evenData)
    {
        if (_currentPair == null)
        {
            return;
        }
        _currentPair.TurnBack();
        endDraggingItemChangeEvent?.Invoke(_currentPair, evenData);
        _currentPair = null;
    }
}
