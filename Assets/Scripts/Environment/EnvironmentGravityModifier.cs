using UnityEngine;

public class EnvironmentGravityModifier : EnvironmentModifierBase
{
    public override void Modify()
    {
        var gravFactor = isIncreasing ? factor : -factor;
        var newGravity = Mathf.Clamp(targetRb.gravityScale + gravFactor, minValue, maxValue);

        targetRb.gravityScale = newGravity;
        Debug.Log($"[env] {name}: Gravity modified to {newGravity}");
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
        if (!collider.ComparePlayerTag())
            return;

        Modify();
    }
}
