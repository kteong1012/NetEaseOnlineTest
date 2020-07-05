using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardMergeResponse
{
    Success,
    Fail_TypeWrong,
    Fail_NoEnoughSources,
	Fail_ExceptionFail
}

public interface ICardMergeResult
{
    CardMergeResponse response { get; set; }
	string description { get; set; }
	CardData card { get; set; }
}

public class CardMergeResult : ICardMergeResult
{
	public CardMergeResponse response { get; set; }
	public string description { get; set; }

	public CardData card { get; set; }

	public CardMergeResult(CardMergeResponse response ,CardData card, string desc = "")
	{
		this.response = response;
		this.description = string.IsNullOrEmpty(desc) ? response.ToString() : desc;
		this.card = card;
	}
}
