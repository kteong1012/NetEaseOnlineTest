using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardMergeBag : BagBase
{
	public CardMergeBag(List<BagItemType> canAddTypes, int maxItemCount) : base(canAddTypes, maxItemCount) { }

	public ICardMergeResult Merge()
	{
		if (_items.Count < maxItemCount)
		{
			return new CardMergeResult(CardMergeResponse.Fail_NoEnoughSources, null);
		}
		else
		{
			CardData card = MergeCards();
			if (card != null)
			{
				return new CardMergeResult(CardMergeResponse.Success, card);
			}
			else
			{
				return new CardMergeResult(CardMergeResponse.Fail_ExceptionFail, null);
			}
		}
	}
	public void Clear()
	{
		_items.Clear();
	}

	private CardData MergeCards()
	{
		//卡的类型这里直接先写死
		CardData mergedCard = CardConfig.Instance.CreateCardByCode(10);
		return mergedCard;
	}
}
