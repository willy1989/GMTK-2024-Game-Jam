using UnityEngine;

public class EnvironmentScaleModifierInstantaneous : EnvironmentScaleModifierBase
{
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerStay2D(collider);
        if (!collider.ComparePlayerTag())
            return;

        ModifyScaleAndMass();
    }
}
