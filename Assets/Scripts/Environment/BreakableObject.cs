using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private float breakMassThreshold = 2f;
    [SerializeField] private int damagePerImpact = 1;
    [SerializeField] private float impactForceThreshold = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.ComparePlayerTag())
            return;

        var rb = collision.gameObject.GetComponent<Rigidbody2D>();
        var impactForce = collision.relativeVelocity.magnitude * rb.mass;

        if (rb.mass >= breakMassThreshold && impactForce >= impactForceThreshold)
            TakeDamage(damagePerImpact);
    }

    // TODO: some visual effect 
    private void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"[BreakableObject] Took {damage} damage. Remaining health: {health}");

        if (health <= 0)
            Break();
    }

    private void Break()
    {
        Debug.Log("[BreakableObject] broken!");
        Destroy(gameObject);
    }
}
