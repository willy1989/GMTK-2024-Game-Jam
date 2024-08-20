using UnityEngine;
using UnityEngine.Events;

public class EndOfLevelZone : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public event UnityAction EndOfLevelReachedEvent;
    private bool endReached;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (endReached
            || collider.gameObject.CompareTag("Player") == false
            || !collider.gameObject.TryGetComponent<Rigidbody2D>(out var rigidBody)
            || rigidBody.velocity.magnitude >= 0.5f)
            return;

        Debug.Log("End of level reached.");
        EndOfLevelReachedEvent?.Invoke();
        audioSource.PlayOneShot(audioSource.clip);
        endReached = true;
    }
}
