using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 offset;
    private float smoothSpeed = 0.8f;
    //private float zPos;
    //private float yPos;


    private void Start()
    {
       //yPos = transform.position.y;
    }

    void LateUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, _player.position, 0.9f) + offset;
        Vector3 desiredPosition = _player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(transform.position.x, transform.position.y, smoothedPosition.z);

    }
}
