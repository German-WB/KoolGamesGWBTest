using UnityEngine;

public class DeletePlayerPrefs : MonoBehaviour
{
    [SerializeField] private LevelSelection _lvlselection;
    public void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
        _lvlselection.CheckLockedLvls();
    }
}
