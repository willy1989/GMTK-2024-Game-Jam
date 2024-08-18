using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private Config config;
    [SerializeField] private AudioSource musicSource;

    private void Start()
    {
        PlayMusic(SceneManager.GetActiveScene().name);
    }

    protected override void OnActiveSceneChanged(Scene prev, Scene next)
    {
        base.OnActiveSceneChanged(prev, next);
        PlayMusic(next.name);
    }

    private void PlayMusic(string levelName)
    {
        var level = config.GetLevelBySceneName(levelName);
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
