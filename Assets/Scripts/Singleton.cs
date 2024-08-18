using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }
    private bool hasInit;

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = (T)(Object)this;
            DontDestroyOnLoad(gameObject);
            Init();
            hasInit = true;
            return;
        }
        Debug.Log("[singleton] Destroying redundant instance " + name);
        Destroy(gameObject);
    }

    protected virtual void Init()
    {
        Debug.Log($"[singleton] {GetType()} {name} initializing...");
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    protected virtual void OnActiveSceneChanged(Scene prev, Scene next)
    {
        Debug.Log($"[singleton] {name} active scene changed from {prev} to {next}");
    }

    protected virtual void OnSceneUnloaded(Scene scene)
    {
        Debug.Log($"[singleton] {name} scene unloaded: {scene}");
    }

    protected virtual void OnDestroy()
    {
        if (hasInit)
        {
            SceneManager.activeSceneChanged -= OnActiveSceneChanged;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }
        hasInit = false;
    }
}
