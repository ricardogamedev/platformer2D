using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{

    public int coins;
  //  public TMP_Text text;
    public TextMeshProUGUI uiTextCoins;

    private void Start()
    {
        Reset();
    }
    private void Reset()
    {
        coins = 0;
        UpdateUI();
        //  text.text = coins.ToString("X " + coins);
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        //  text.text = coins.ToString("X "+ coins);
        UpdateUI();
    }

    private void UpdateUI()
    {
        uiTextCoins.text = coins.ToString("X " + coins);
    }



}
