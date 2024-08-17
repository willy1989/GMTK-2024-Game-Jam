using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ColliderWithCallback : MonoBehaviour
{
    public UnityAction Callback;
    [SerializeField] private bool isPlayerOnly;

    public void Init(UnityAction cb)
    {
        Callback = cb;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlayerOnly && !collision.ComparePlayerTag())
            return;

        Callback?.Invoke();
    }
}
