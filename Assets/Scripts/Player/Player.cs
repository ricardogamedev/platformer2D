using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public AudioSource myAudioSource;
    // public Animator animator;
    public HealthBase healthBase;

    private float _currentSpeed;
   

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;

    private Animator _currentPlayer;

    [Header("Jump Collision Check")]
    public Collider2D collider2D;
    public float distToGround;
    public float spaceToGround = .1f;
    public ParticleSystem jumpVFX;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }

        _currentPlayer = Instantiate(soPlayerSetup.player, transform);

        var gun = _currentPlayer.GetComponentInChildren<GunBase>();
        if (gun != null)
        {
            gun.playerSideReference = transform;
        }

        if (collider2D != null)
        {
            distToGround = collider2D.bounds.extents.y;
        }
    }

    private bool IsGrounded()
    {
        // Debug.DrawRay(transform.position, -Vector2.up, Color.magenta, distToGround + spaceToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + spaceToGround);
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(soPlayerSetup.triggerDeath);
        myRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
   

    }


    private void Update()
    {
        IsGrounded();
        HandleJump();
        HandleMovement();
    }
    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = soPlayerSetup.speedRun;
            _currentPlayer.speed = 2;
        }

        else
        {
            _currentSpeed = soPlayerSetup.speed;
            _currentPlayer.speed = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);

            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, soPlayerSetup.playerSwipeDuration);
            }

            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);

            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, soPlayerSetup.playerSwipeDuration);
            }
            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        }
        else
        {
            _currentPlayer.SetBool(soPlayerSetup.boolRun, false);
        }

        //nesse if de baixo, se a velocidade em x é maior que zero, personagem está andando. Aí eu desacelero com a fricção a cada frame
        // a soma ou subtração da fricção depende do eixo X, para a esquerda ele é negativo, por isso vamos subtraindo
        if (myRigidbody.velocity.x > 0)
        {            
            myRigidbody.velocity += soPlayerSetup.friction;
        }
        else if (myRigidbody.velocity.x < 0)        {
         
            myRigidbody.velocity -= soPlayerSetup.friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            myRigidbody.velocity = Vector2.up * soPlayerSetup.forceJump;


            DOTween.Kill(myRigidbody.transform);
            HandleScaleJump();
            PlayJumpSound();
            PlayJumpVFX();
        }
    }

    private void PlayJumpVFX()
    {
        VFXManager.Instance.PlayVFXByType(VFXManager.VFXType.JUMP, transform.position);
        //    if (jumpVFX != null) jumpVFX.Play();
    }

    public void PlayJumpSound()
    {
        myAudioSource.Play();
    }



    private void HandleScaleJump()
    {
        float scaleTarget = myRigidbody.transform.localScale.x > 0 ? soPlayerSetup.jumpScaleX : -soPlayerSetup.jumpScaleX;

        myRigidbody.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        myRigidbody.transform.DOScaleX(scaleTarget, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}

