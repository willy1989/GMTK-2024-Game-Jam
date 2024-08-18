using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerControllerBase : MonoBehaviour
{
    public event UnityAction OnActionMade;
    protected bool isFrozen;

    private void Awake()
    {
        // Freeze in tutorial screen 
        var tm = FindObjectOfType<TutorialManager>();
        tm.OnTutorialOpened += OnTutorialOpened;
        tm.OnTutorialClosed += OnTutorialClosed;
    }

    private void OnTutorialOpened()
    {
        isFrozen = true;
    }

    private void OnTutorialClosed()
    {
        isFrozen = false;
    }

    private void OnDestroy()
    {
        var tm = FindObjectOfType<TutorialManager>();
        if (tm != null)
        {
            tm.OnTutorialOpened -= OnTutorialOpened;
            tm.OnTutorialClosed -= OnTutorialClosed;
        }
    }
}
