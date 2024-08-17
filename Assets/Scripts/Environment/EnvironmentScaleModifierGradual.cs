using UnityEngine;

public class EnvironmentScaleModifierGradual : EnvironmentScaleModifierBase
{
    protected override float ScaleFactor => base.ScaleFactor * Time.deltaTime;

    protected override void OnTriggerStay2D(Collider2D collider)
    {
        base.OnTriggerStay2D(collider);
        if (!collider.ComparePlayerTag())
            return;

        Modify();
    }
}
