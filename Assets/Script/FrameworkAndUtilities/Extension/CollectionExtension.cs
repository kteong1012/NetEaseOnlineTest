using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollectionExtension
{
    public static bool TrySafelyAdd<TKey,TValue> (this Dictionary<TKey, TValue> dict,TKey key,TValue value)
    {
        if (dict.ContainsKey(key))
        {
            return false;
        }
        dict.Add(key, value);
        return true;
    }
    public static bool TrySafelyRemove<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
    {
        if (!dict.ContainsKey(key))
        {
            return false;
        }
        dict.Remove(key);
        return true;
    }
    public static bool TrySafelyAdd<T>(this List<T> list, T element)
    {
        if (list.Contains(element))
        {
            return false;
        }
        list.Add(element);
        return true;
    }
    public static bool TrySafelyRemove<T>(this List<T> list, T element)
    {
        if (!list.Contains(element))
        {
            return false;
        }
        list.Remove(element);
        return true;
    }
}
