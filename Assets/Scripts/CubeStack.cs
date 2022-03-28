using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStack : MonoBehaviour
{

    [SerializeField] private Transform stackParent;
    private Vector3 newPos;
    private GameObject lastCube;
    private WaitForEndOfFrame _waitFrame;
    private readonly List<GameObject> stackedCubeList = new List<GameObject>();
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
            stackedCubeList.Add(Cube.gameObject);
            SoundManager.PlaySound(SoundManager.Sound.CubeStack, GetPosition());
        }

        if (other.CompareTag("EnemyCube"))
        {
            if(stackedCubeList.Count == 0)
            {
                Destroy(this.gameObject);
            }
            stackParent.localPosition += Vector3.down;

            other.GetComponent<BoxCollider>().enabled = false;

            GameObject cubeToDestroy = stackedCubeList[stackedCubeList.Count - 1];
            stackedCubeList.RemoveAt(stackedCubeList.Count - 1);
            Destroy(cubeToDestroy);
            SoundManager.PlaySound(SoundManager.Sound.WallHit, GetPosition());
            Debug.Log(stackedCubeList.Count);
        }
    }

    private Vector3 GetPosition()
    {
        return transform.position;
    }
        //Generamos obstáculo
    //Generamos cada columna
    //Si hay numero 1, añadimos a lista lvl1 row
    //Si hay numero 2, añadimos a lista lvl2 row
}

