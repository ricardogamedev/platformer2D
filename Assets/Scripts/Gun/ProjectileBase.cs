using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector3 direction;
    public float timeToDestroy = 3;
    public float side = 1;

    public int damageAmount = 1;

    private void Awake()
    {
        PlayShootVFX();
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * side);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();

        if(enemy != null)
        {
            enemy.Damage(damageAmount);
            Destroy(gameObject);
        }
    }

    private void PlayShootVFX()
    {
        VFXManager.Instance.PlayVFXByType(VFXManager.VFXType.LASER, transform.position);
    }
}
