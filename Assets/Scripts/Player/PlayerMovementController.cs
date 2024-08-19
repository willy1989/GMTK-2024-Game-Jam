using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementController : PlayerControllerBase
{
    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private float forceAmount;

    public override event UnityAction OnActionMade;

    private void Update()
    {
        if (isFrozen)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            AddForce(Vector2.up);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AddForce(Vector2.down);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AddForce(Vector2.left);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AddForce(Vector2.right);
        }
    }

    private void AddForce(Vector2 force)
    {
        rigidBody.AddForce(force * forceAmount, ForceMode2D.Impulse);
        OnActionMade?.Invoke();
        AudioManager.Instance.PlaySoundEffect("AddForce");
    }
}
