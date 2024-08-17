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

public abstract class EnvironmentScaleModifierBase : EnvironmentModifierBase
{
    protected virtual float ScaleFactor => factor;

    public override void Modify()
    {
        var scale = targetRb.transform.localScale;
        var newScale = scale;
        var factor = isIncreasing ? ScaleFactor : -ScaleFactor;

        if (axes.X)
        {
            newScale.x = Mathf.Clamp(scale.x + factor, minValue, maxValue);
        }

        if (axes.Y)
        {
            // TODO: may need to rework this so it can increase OR decrease height
            if (axes.YOnlyUp && isIncreasing)
            {
                var yOffset = factor / 2f;
                newScale.y = Mathf.Clamp(scale.y + factor, minValue, maxValue);
                targetRb.transform.position += new Vector3(0, yOffset, 0);
            }
            else
            {
                newScale.y = Mathf.Clamp(scale.y + factor, minValue, maxValue);
            }
        }

        targetRb.transform.localScale = newScale;

        // Assuming uniform scaling, calculate the mass based on x scale ratio
        var scaleRatio = newScale.x / scale.x;
        targetRb.mass *= scaleRatio;
    }
}
