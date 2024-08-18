using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerControllerBase : MonoBehaviour
{
    public abstract event UnityAction OnActionMade;
    protected bool isFrozen;

    private void Awake()
    {
        // Freeze when UI is open  
        var uim = FindObjectOfType<UIManager>();
        uim.OnOpened += OnUIOpened;
        uim.OnClosed += OnUIClosed;
    }

    private void OnUIOpened()
    {
        isFrozen = true;
    }

    private void OnUIClosed()
    {
        isFrozen = false;
    }

    private void OnDestroy()
    {
        var uim = FindObjectOfType<UIManager>();
        if (uim != null)
        {
            uim.OnOpened -= OnUIOpened;
            uim.OnClosed -= OnUIClosed;
        }
    }
}
