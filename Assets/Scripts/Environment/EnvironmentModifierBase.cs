using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class EnvironmentModifierBase : MonoBehaviour
{
    [SerializeField] protected float factor = 0.1f;
    [SerializeField] protected float maxValue = 3f;
    [SerializeField] protected float minValue = 0.5f;
    [SerializeField] protected Axes axes;
    [SerializeField] protected bool isIncreasing = true;
    [SerializeField] protected Rigidbody2D targetRb;

    public abstract void Modify();

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.ComparePlayerTag())
        {
            return;
        }

        //Debug.Log($"[env] {name} Trigger entered");
    }

    protected virtual void OnTriggerStay2D(Collider2D collider)
    {
        if (!collider.ComparePlayerTag())
        {
            return;
        }

        //Debug.Log($"[env] {name} Trigger stay");
    }
}
