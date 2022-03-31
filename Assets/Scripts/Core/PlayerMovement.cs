using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _dragSpeed = 1f;
    [SerializeField] private float _forwardSpeed = 1f;
    private Vector3 lastMousePos;

    private void Update()
    {
        transform.Translate(0, 0, _forwardSpeed * Time.deltaTime) ;
    }

    void OnMouseDown()
    {
        lastMousePos = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        if (GameManager.instance.isPlaying)
        {
            Vector3 delta = Input.mousePosition - lastMousePos;
            Vector3 pos = transform.position;
            pos.x += delta.x * _dragSpeed;
            transform.position = new Vector3(Mathf.Clamp(pos.x, -1.75f, 1.75f), pos.y, pos.z);
            lastMousePos = Input.mousePosition;      
        }
    }
}
