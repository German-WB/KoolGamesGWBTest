using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData")]

public class LevelData : ScriptableObject
{
    public List<Transform> cubeList;
}
