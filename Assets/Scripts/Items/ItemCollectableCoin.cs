using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{

    public bool isCoinSpecial = false;

    protected override void OnCollect()
    {
        base.OnCollect();

        if(isCoinSpecial)
        ItemManager.Instance.AddCoins(2);
        else
        ItemManager.Instance.AddCoins();
    }
}
