using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaleController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private int uses = 0;

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
        if (uses == 0)
            return;

        transform.localScale = transform.localScale * multiplier;
        rigidBody.mass *= multiplier;

        uses--;
    }
}
