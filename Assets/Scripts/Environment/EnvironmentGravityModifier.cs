using UnityEngine;

public class EnvironmentGravityModifier : EnvironmentModifierBase
{
    [SerializeField] private bool isSingleUse;
    [SerializeField] private Sprite usedSprite;
    private SpriteRenderer spriteRenderer;
    private bool isUsed;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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
        if (!collider.ComparePlayerTag() || (isSingleUse && isUsed))
            return;

        Modify();
        isUsed = true;

        if (isSingleUse)
        {
            spriteRenderer.sprite = usedSprite;
        }
    }
}
