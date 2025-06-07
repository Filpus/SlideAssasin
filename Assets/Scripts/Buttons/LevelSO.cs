using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class LevelSO : ScriptableObject
{
    public int Number;
    public string Name;
    public Scene? LevelScene;
}
