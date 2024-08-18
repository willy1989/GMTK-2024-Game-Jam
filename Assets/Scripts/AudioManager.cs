using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private Config config;
    [SerializeField] private AudioSource musicSource;

    public override void Init()
    {
        base.Init();
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    private void Start()
    {
        PlayMusic(SceneManager.GetActiveScene().name);
    }

    private void OnActiveSceneChanged(Scene prev, Scene next)
    {
        Debug.Log($"[audio] active scene changed from {prev} to {next}");
        PlayMusic(next.name);
    }

    private void PlayMusic(string levelName)
    {
        var level = config.Levels.FirstOrDefault(l => l.SceneName == levelName);
        if (level == null)
        {
            Debug.LogError("[audio] level not found: " + levelName);
            return;
        }

        if (level.Music == null)
        {
            Debug.LogWarning("[audio] no music found for level " + level.SceneName);
            return;
        }

        Debug.Log("[audio] playing " + level.Music.name);
        musicSource.Stop();
        musicSource.clip = level.Music;
        musicSource.Play();
    }
}
