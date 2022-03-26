using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStack : MonoBehaviour
{

    [SerializeField] private Transform stackParent;
    private Vector3 newPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            Transform Cube = other.transform.parent;
            Cube.gameObject.layer = LayerMask.NameToLayer("CubeStacked");
            other.gameObject.layer = LayerMask.NameToLayer("CubeStacked");

            newPos = stackParent.localPosition;
            newPos.y += 1f;
            newPos.x = 0;
            newPos.z = 0;
            stackParent.localPosition = newPos;

            Cube.SetParent(stackParent);
            newPos.y *= -1f;
            Cube.localPosition = newPos;
            Cube.localRotation = Quaternion.identity;
        }
    }
}
