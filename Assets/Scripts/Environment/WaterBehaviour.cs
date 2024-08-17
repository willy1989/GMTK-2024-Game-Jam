using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class WaterBehaviour : MonoBehaviour
{
    [SerializeField] private float buoyancyFactor = 2.0f;
    [SerializeField] private float waterDrag = 2.0f;
    [SerializeField] private float angularDrag = 1.0f;
    /// <summary>
    /// Points after which object in water starts to sink 
    /// </summary>
    [SerializeField] private float maxBuoyancyScale = 1.5f;
    [SerializeField] private float maxBuoyancyMass = 5f;

    private float originalDrag;
    private float originalAngularDrag;
    private Rigidbody2D playerRb;
    private bool isInWater = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.ComparePlayerTag())
            return;

        playerRb = collider.attachedRigidbody;
        isInWater = true;

        originalDrag = playerRb.drag;
        originalAngularDrag = playerRb.angularDrag;

        playerRb.drag = waterDrag;
        playerRb.angularDrag = angularDrag;

        Debug.Log("[env] Entered water");
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (!isInWater)
            return;

        // TODO: use x scale as well? 
        var scale = playerRb.transform.localScale.y;
        var mass = playerRb.mass;
        var buoyancyForce = buoyancyFactor * Mathf.Abs(Physics2D.gravity.y) * scale;

        // Adjust buoyancy based on mass and scale
        if (scale > maxBuoyancyScale || mass > maxBuoyancyMass)
        {
            var scaleRatio = Mathf.Clamp01(maxBuoyancyScale / scale);
            var massRatio = Mathf.Clamp01(maxBuoyancyMass / mass);
            var adjustedBuoyancy = buoyancyForce * scaleRatio * massRatio;

            playerRb.AddForce(new Vector2(0, adjustedBuoyancy), ForceMode2D.Force);
        }
        else
        {
            playerRb.AddForce(new Vector2(0, buoyancyForce), ForceMode2D.Force);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (!collider.ComparePlayerTag() || !isInWater)
            return;

        // Reset rb 
        playerRb.drag = originalDrag;
        playerRb.angularDrag = originalAngularDrag;

        isInWater = false;
        Debug.Log("[env] Exited water");
    }
}
