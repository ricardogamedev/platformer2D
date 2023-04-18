using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    [SerializeField] private Transform _initialPosition;
    [SerializeField] private Transform _position;
    [SerializeField] private float _speed;
    [SerializeField] private float _time;
    [SerializeField] private int _length;


    private void Start()
    {
        transform.position = _initialPosition.position;
    }

    private void Update()
    {
        MovePlatform();
    }

    public void MovePlatform()
    {
        _time = Mathf.PingPong(Time.time * _speed, _length);
        transform.position = Vector3.Lerp(_initialPosition.transform.position, _position.transform.position, _time);
    }

}
