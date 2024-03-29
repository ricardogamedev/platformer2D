using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{

    public bool isCoinSpecial = false;


    protected override void OnCollect()
    {
        PlayCoinVFX();
        base.OnCollect();

        if (isCoinSpecial)
            ItemManager.Instance.AddCoins(2);
        else
            ItemManager.Instance.AddCoins();
    }

    public void PlayCoinVFX()
    {
        VFXManager.Instance.PlayVFXByType(VFXManager.VFXType.COIN, transform.position);
    }
}
