using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public Action OnKill;
    public int startLife = 10;

    public bool destroyOnKill = false;
    public float delayToKill = 0f;

    private int _currentLife;
    private bool _isDead = false;
    public FlashColor flashColor;

    private void Awake()
    {
        Init();        
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;
        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Kill();
        }
                
        if (flashColor != null)
        {
            flashColor.Flash();
        }

    }

    private void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }

        // if (OnKill != null) OnKill.Invoke(); abaixo o jeito mais chique de escrever a mesma coisa
        OnKill?.Invoke();
    }

}
