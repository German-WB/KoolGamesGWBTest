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
            SoundManager.PlaySound(SoundManager.Sound.CubeStack);
        }

        if (other.CompareTag("EnemyCube"))
        {
            if(stackedCubeList.Count == 0)
            {
                SoundManager.PlaySound(SoundManager.Sound.WallHit);
                Destroy(this.gameObject);
            }
            stackParent.localPosition += Vector3.down;

            other.GetComponent<BoxCollider>().enabled = false;

            GameObject cubeToDestroy = stackedCubeList[stackedCubeList.Count - 1];
            stackedCubeList.RemoveAt(stackedCubeList.Count - 1);
            Destroy(cubeToDestroy);
            Debug.Log(stackedCubeList.Count);
        }
    }

    //Generamos obst�culo
    //Generamos cada columna
    //Si hay numero 1, a�adimos a lista lvl1 row
    //Si hay numero 2, a�adimos a lista lvl2 row
}

