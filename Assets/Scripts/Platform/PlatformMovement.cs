using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public GameObject platformPathStart;
    public GameObject platformPathEnd;
    public int speed = 10;
    public float time = 0f;
    private Vector3 _startPosition;
    private Vector3 _endPosition;

    void Start()
    {
        _startPosition = platformPathStart.transform.position;
        _endPosition = platformPathEnd.transform.position;
        //        StartCoroutine(PlatformMovementCoroutine(gameObject, _endPosition, speed));
        StartCoroutine(PlatformMovementCoroutine(gameObject, _endPosition, speed));
    }

    IEnumerator PlatformMovementCoroutine(GameObject gameObject, Vector3 target, float speed)
    {
        _startPosition = gameObject.transform.position;

        while (gameObject.transform.position != target)
        {
            gameObject.transform.position = Vector3.Lerp(_startPosition, target, speed);
            speed += Time.deltaTime * time;
            yield return null;

        }

    }

    public void MovePlatform(Vector3 startPosition, Vector3 endPosition, float speed)
    {
        gameObject.transform.position = Vector3.Lerp(_startPosition, _endPosition, (speed * Time.deltaTime));
    }

    /*
    IEnumerator PlatformMovementCoroutine(GameObject obj, Vector3 target, float speed)
    {
        Vector3 _startPosition = obj.transform.position;
        float time = 0f;

        while (obj.transform.position != target)
        {
            obj.transform.position = Vector3.Lerp(_startPosition, target, (time / Vector3.Distance(_startPosition, target)) * speed);
            time += Time.deltaTime;
            yield return null;
        }
    }
    */
}
