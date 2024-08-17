using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private float forceAmount;

    [SerializeField] private int uses = 0;

    private void Update()
    {
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
        if (uses == 0)
            return;

        rigidBody.AddForce(force * forceAmount, ForceMode2D.Impulse) ;
        uses--;
    }

    




}
