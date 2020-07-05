using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagsManager : Singleton<BagsManager>
{
    //这里按理来说是根据线上或者其他方式获取存档，不过只是demo的话就不那么麻烦多做一个功能模块了
    //所以我打算直接在这里写死了，在运行时初始化卡牌背包
    public BagBase normalCardBag;
    public BagBase rareCardBag;
    public BagsManager()
    {
        normalCardBag = new BagBase(new List<BagItemType>() { BagItemType.Normal_Card }, 20);
        rareCardBag = new BagBase(new List<BagItemType>() { BagItemType.Rare_Card }, 20);

        normalCardBag.AddBagItem(CardConfig.Instance.CreateCardByCode(1));
        normalCardBag.AddBagItem(CardConfig.Instance.CreateCardByCode(2));
        normalCardBag.AddBagItem(CardConfig.Instance.CreateCardByCode(3));
        normalCardBag.AddBagItem(CardConfig.Instance.CreateCardByCode(3));
    }
}
