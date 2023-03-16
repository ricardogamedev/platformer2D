using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 5;

    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerKill = "Kill";
    public float timeToDestroy = 1f;
    public AudioSource myAudioSource;
    public EnemyMovement enemyMovement;

    public HealthBase healthBase;

    private void Awake()
    {
        if (healthBase != null)
        {
            //callback
           // PlayDamageTakenNoise();
            healthBase.OnKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        PlayKillAnimation();
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision.transform.name);
        var health = collision.gameObject.GetComponent<HealthBase>();

        if (health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }
    private void PlayKillAnimation()
    {
        animator.SetTrigger(triggerKill);
    }

    private void PlayDamageTakenNoise()
    {     
        myAudioSource.Play();
    }

    public void Damage(int amount)
    {
        PlayDamageTakenNoise();
        healthBase.Damage(amount);
    }
}
