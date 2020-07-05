using System.IO;
using UnityEngine;

public abstract class MessageBase
{
    public MessageType messageType;
    public bool once = false;
    public bool mustBeHandled = false;
}

public enum MessageType
{
    BagItemClick,
    BagItemChange,
    CardMergeSuccess,
}

public class BagItemClickMessage : MessageBase
{
    public BagItemView item;
    public BagItemClickMessage(BagItemView item)
    {
        messageType = MessageType.BagItemClick;
        this.item = item;
    }
}
public class BagItemChangeMessage : MessageBase
{
    public BagBase bag;
    public BagItemChangeMessage(BagBase bag)
    {
        messageType = MessageType.BagItemChange;
        this.bag = bag;
    }
}
public class CardMergeSuccessMessage : MessageBase
{
    public CardData card;
    public CardMergeSuccessMessage(CardData card)
    {
        messageType = MessageType.CardMergeSuccess;
        this.card = card;
    }
}