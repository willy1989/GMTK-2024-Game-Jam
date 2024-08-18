using UnityEngine;
using UnityEngine.Events;

public class EndOfLevelZone : MonoBehaviour
{
    public event UnityAction EndOfLevelReachedEvent;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") == false)
            return;

        if (!collider.gameObject.TryGetComponent<Rigidbody2D>(out var rigidBody))
            return;

        if (rigidBody.velocity.magnitude < 0.5f)
        {
            Debug.Log("End of level reached.");
            EndOfLevelReachedEvent?.Invoke();
        }
    }
}
