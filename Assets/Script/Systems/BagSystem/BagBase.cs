using System;
using System.Collections.Generic;
public class BagBase
{
	public List<BagItemType> canAddTypes;
	public int maxItemCount;
	public List<IBagItem> Items => _items;

	protected List<IBagItem> _items = new List<IBagItem>();
	public BagBase(List<BagItemType> canAddTypes, int maxItemCount)
	{
		this.canAddTypes = canAddTypes;
		this.maxItemCount = maxItemCount;
	}
	public IBagItemChangeResult AddBagItem(IBagItem item)
	{
		//这里判断满了没
		if (_items.Count >= maxItemCount)
		{
			return new BagItemChangeResult(BagItemChangeResponse.AddFail_Full);
		}
		//这里判断物品类型
		if (CheckItemTypeCanAdd(item.ItemType))
		{
			if(_items.TrySafelyAdd(item))
			{
				return new BagItemChangeResult(BagItemChangeResponse.Success);
			}
			else
			{
				return new BagItemChangeResult(BagItemChangeResponse.Fail_Exception);
			}
		}
		else
		{
			return new BagItemChangeResult(BagItemChangeResponse.AddFail_WrongType);
		}
	}
	public IBagItemChangeResult RemoveBagItem(IBagItem item)
	{
		if (_items.TrySafelyRemove(item))
		{
			return new BagItemChangeResult(BagItemChangeResponse.Success);
		}
		else
		{
			return new BagItemChangeResult(BagItemChangeResponse.Fail_Exception);
		}
	}

	private bool CheckItemTypeCanAdd(BagItemType type)
	{
		//这里是判断物品类型
		bool result = false;
		foreach (var t in canAddTypes)
		{
			if(t == type)
			{
				return true;
			}
		}
		return result;
	}
}
