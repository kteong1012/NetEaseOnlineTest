using System;
using System.Collections.Generic;

public enum CardLevel
{
    C = 1,
    B = 2,
    A = 3,
    S = 4
}
public enum CardRarity
{
    Normal = 1,
    Rare = 2,
}
public enum CardRace
{
    Demon,
    Human,
    Elf,
    Ghost
}
[Serializable]
public class CardData : IBagItem
{
    //背包接口相关
    private BagItemType _itemType;
    public BagItemType ItemType { get { return _itemType; } set { _itemType = value; } }

    //卡牌属性
    public int code;
    public CardRarity rarity;
    public CardLevel level;
    public float attack = 0;
    public float defence = 0;
    public float evade = 0;
    public float critRate = 0;
    public List<int> cardSkillCodes = new List<int>();
}
