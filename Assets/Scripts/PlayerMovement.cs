using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int _speed;

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float hspeed = Input.GetAxis("Horizontal");
        float vspeed = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(hspeed * _speed, 0f, vspeed * _speed);
        transform.Translate(direction * Time.deltaTime);
    }
}
