using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public float dragSpeed = 1f;
    Vector3 lastMousePos;
    private float clampedValue;

    private void Update()
    {
        clampedValue = Mathf.Clamp(transform.position.x, -1.75f, 1.75f);        
    }
    void OnMouseDown()
    {
        lastMousePos = Input.mousePosition;
    }
    void OnMouseDrag()
    {
        Vector3 delta = Input.mousePosition - lastMousePos;
        Vector3 pos = transform.position;
        pos.x += delta.x * dragSpeed;
        transform.position = new Vector3(Mathf.Clamp(pos.x, -1.75f, 1.75f), pos.y, pos.z);
        lastMousePos = Input.mousePosition;      
    }

}
