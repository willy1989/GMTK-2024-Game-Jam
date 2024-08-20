using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/Config", order = 1)]
public class Config : ScriptableObject
{
    public Level[] Levels;

    public Level GetLevelBySceneName(string name)
    {
        return Levels.FirstOrDefault(l => l.SceneName == name);
    }

    private void OnValidate()
    {
        if (Levels.Any(l => l.BaseScore <= 0 || l.ActionPenalty <= 0))
        {
            Debug.LogWarning("Base scores and/or move penalties invalid: <= 0");
        }
    }
}

[Serializable]
public class Level
{
    public string SceneName;
    public string DisplayName;
    public AudioClip Music;
    public int BaseScore;
    public int ActionPenalty;
}