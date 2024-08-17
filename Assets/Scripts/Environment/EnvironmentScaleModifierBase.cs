using System;
using UnityEngine;

[Serializable]
public record Axes
{
    public bool X = true;
    public bool Y = true;
    /// <summary>
    /// i.e. only increase height 
    /// </summary>
    public bool YOnlyUp;
}

public abstract class EnvironmentScaleModifierBase : MonoBehaviour
{
    [SerializeField] private float scaleFactor = 0.1f;
    [SerializeField] private float maxScale = 3f;
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private Axes axes;
    [SerializeField] private bool isIncreasing = true;
    [SerializeField] private Rigidbody2D targetRb;

    protected virtual float ScaleFactor => scaleFactor;

    protected virtual void ModifyScaleAndMass()
    {
        var scale = targetRb.transform.localScale;
        var newScale = scale;
        var factor = isIncreasing ? ScaleFactor : -ScaleFactor;

        if (axes.X)
        {
            newScale.x = Mathf.Clamp(scale.x + factor, minScale, maxScale);
        }

        if (axes.Y)
        {
            // TODO: may need to rework this so it can increase OR decrease height
            if (axes.YOnlyUp && isIncreasing)
            {
                var yOffset = factor / 2f;
                newScale.y = Mathf.Clamp(scale.y + factor, minScale, maxScale);
                targetRb.transform.position += new Vector3(0, yOffset, 0);
            }
            else
            {
                newScale.y = Mathf.Clamp(scale.y + factor, minScale, maxScale);
            }
        }

        targetRb.transform.localScale = newScale;

        // Assuming uniform scaling, calculate the mass based on x scale ratio
        var scaleRatio = newScale.x / scale.x;
        targetRb.mass *= scaleRatio;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.ComparePlayerTag())
        {
            return;
        }

        Debug.Log($"[env] {name} Trigger entered");
        ModifyScaleAndMass();
    }

    protected virtual void OnTriggerStay2D(Collider2D collider)
    {
        if (!collider.ComparePlayerTag())
        {
            return;
        }

        Debug.Log($"[env] {name} Trigger stay");
        ModifyScaleAndMass();
    }
}
