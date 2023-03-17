using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;

public class UIInGameManager : Singleton<UIInGameManager>
{
    public TextMeshProUGUI uiTextCoins;
    public UIShowGameOver showGameOver;
    [SerializeField] private UIShowGameOver uIShowGameOver;

    public static void UpdateTextCoins(string s)
    {
        Instance.uiTextCoins.text = s;
    }



}
