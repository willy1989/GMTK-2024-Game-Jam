using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private float forceAmount;

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
        rigidBody.AddForce(force * forceAmount, ForceMode2D.Impulse) ;
    }

    




}
