using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Sound effect database", menuName = "ScriptableObjects/SoundEffectDatabase", order = 1)]
public class SoundEffectDatabase : ScriptableObject
{
    [SerializeField] private SoundEffectData[] soundEffectDatas;

    public SoundEffectData SoundEffectData(string soundEffectName)
    {
        foreach(SoundEffectData soundEffectData in soundEffectDatas)
        {
            if(soundEffectName == soundEffectData.SoundEffectName)
                return soundEffectData;
        }

        Debug.LogError("Couldn't find soundEffectData: " +  soundEffectName + " .");

        return null;
    }
}

[Serializable]
public class SoundEffectData
{
    [SerializeField] private string soundEffectName;

    public string SoundEffectName => soundEffectName;

    [SerializeField] private AudioClip audioClip;

    public AudioClip AudioClip => audioClip;
}
