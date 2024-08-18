using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = (T)(Object)this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Debug.Log("Destroying redundant instance " + name);
        Destroy(gameObject);
    }

    public virtual void Init()
    {
        Debug.Log(GetType() + " initializing...");
    }
}
