using UnityEngine;
using UnityEngine.Events;

public class PlayerScaleController : PlayerControllerBase
{
    [SerializeField] private Rigidbody2D rigidBody;

    public event UnityAction OnScaleChanged;

    private void Update()
    {
        if (isFrozen)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeScale(multiplier: 2f);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeScale(multiplier: 0.5f);
        }
    }

    private void ChangeScale(float multiplier)
    {
        transform.localScale = transform.localScale * multiplier;
        rigidBody.mass *= multiplier;
        OnScaleChanged?.Invoke();
    }
}
