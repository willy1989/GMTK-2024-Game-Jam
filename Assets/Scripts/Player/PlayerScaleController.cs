using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaleController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;

    private void Update()
    {
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
    }
}
