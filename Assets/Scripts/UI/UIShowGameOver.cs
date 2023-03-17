using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShowGameOver : MonoBehaviour
{

    public PauseManager pauseManager;
  public void GameOverUI()
    {
        gameObject.SetActive(true);
        pauseManager.Pause();

    }
}
