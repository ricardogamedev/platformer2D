using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public float speed = 1;


    private Vector2 destination;
    private Vector2 distanceBetween;


    public void Update()
    {
        MoveEnemy(speed);
    }

    private void MoveEnemy(float speed)
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void StopMoving()
    {
        myRigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;
    }
}
