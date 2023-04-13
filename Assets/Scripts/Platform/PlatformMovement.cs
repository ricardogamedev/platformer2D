using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public List<Transform> positions;
    public Transform position;
    private float _timeElapsed = 0f;
    public float duration = 2f;
    private int _index;

    private void Update()
    {
        LerpingLikeNoTomorrow();
        // MovePlatform();
    }


    private void LerpingLikeNoTomorrow()
    {
        var initialPosition = transform.position;

        while (_timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(initialPosition, position.transform.position, (_timeElapsed/duration));
            _timeElapsed += Time.deltaTime;
        }
        _timeElapsed = 0f;
    }

    /*
    private void MovePlatform()
    {
        float timeElapsed = 0f;

        while (true)
        {
            var currentPosition = transform.position;

            while (_timeElapsed < duration)
            {
                transform.position = Vector3.Lerp(currentPosition, positions[_index].transform.position, (_timeElapsed / duration));
                _timeElapsed += Time.deltaTime;
            }

            NextIndex();
            _timeElapsed = 0;

        }

    }

    private void NextIndex()
    {
        _index++;
        if (_index >= positions.Count) _index = 0;
    }
    */
}
