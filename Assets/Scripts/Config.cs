using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/Config", order = 1)]
public class Config : ScriptableObject
{
    public Level[] Levels;
}

[Serializable]
public class Level
{
    public string SceneName;
    public AudioClip Music;
}