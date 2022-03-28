using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int _horizontalSpeed;
    [SerializeField] private int _forwardSpeed;

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float hspeed = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(hspeed * _horizontalSpeed, 0f, _forwardSpeed);
        transform.Translate(direction * Time.deltaTime);
    }
}
