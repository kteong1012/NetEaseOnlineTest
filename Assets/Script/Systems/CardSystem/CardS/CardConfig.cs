using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardConfig : Singleton<CardConfig>
{
    private const string RESOURCE_CONFIG_PATH = "ConfigTables/CardConfig";
    public CardData[] cards;
    public CardConfig()
    {
        CardConfigTable table = Resources.Load<CardConfigTable>(RESOURCE_CONFIG_PATH);
        if (table != null)
        {
            cards = table.cardConfigTable;
        }
    }

    public CardData CreateCardByCode(int code)
    {
        if (cards == null)
        {
            return null;
        }
        CardData result = new CardData();
        result.code = code;
        bool hasCode = false;
        foreach (var card in cards)
        {
            if (result.code == card.code)
            {
                hasCode = true;
                result.rarity = card.rarity;
                result.level = card.level;
                result.attack = card.attack;
                result.defence = card.defence;
                result.evade = card.evade;
                result.critRate = card.critRate;
                result.cardSkillCodes = card.cardSkillCodes;
                switch (result.rarity)
                {
                    case CardRarity.Normal:
                        result.ItemType = BagItemType.Normal_Card;
                        break;
                    case CardRarity.Rare:
                        result.ItemType = BagItemType.Rare_Card;
                        break;
                }
            }
        }
        if (!hasCode)
        {
            Debug.LogError(string.Format("配置表里没有代号为{0}的卡牌。", code));
        }
        return result;
    }
    public Sprite GetCardFrame(CardLevel level)
    {
        string path = "Images/CardFrames/cardframe_" + level.ToString();
        Sprite result = Resources.Load<Sprite>(path);
        return result;
    }
    public Sprite GetCardImageByCode(int code)
    {
        string path = "Images/Cards/card_" + code.ToString();
        Sprite result = Resources.Load<Sprite>(path);
        return result;
    }
}
