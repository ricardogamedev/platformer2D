using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public Transform playerSideReference;
    public AudioSource myAudioSource;

    //  public float timeBetweenShoot = .5f;

    private Coroutine _currentCoroutine;
    /*
    private bool canShoot = true;
    public float fireRate = 5f;
    public float nextShot = 5f;
*/
    public float time = .5f;
    private float timer;

    public void Awake()
    {
        timer = time;
    }


    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                StartShooting();
                timer = time;
            }
        }
        /*
        if (Input.GetKeyDown(KeyCode.S))
        {

            StartShoot();
            _currentCoroutine = StartCoroutine(StartShoot());
        }

        else if (Input.GetKeyUp(KeyCode.S))
        {
            if (_currentCoroutine != null)
                StopCoroutine(_currentCoroutine);
        }
        */
    }

    public void StartShooting()
    {
        PlayShootSound();
        Shoot();
    }
    /*
    IEnumerator StartShoot()
    {
        while (true)
        {
            PlayShootSound();
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);

        }
    }
    */
    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }

    public void PlayShootSound()
    {
        myAudioSource.Play();
    }

}
