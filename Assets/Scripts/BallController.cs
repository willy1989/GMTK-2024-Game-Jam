using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private float forceAmount;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddForceRight();
        }
    }

    private void AddForceRight()
    {
        rigidBody.AddForce(Vector2.right * forceAmount, ForceMode2D.Impulse);
    }


}
