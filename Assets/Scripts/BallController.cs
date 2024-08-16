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
            AddForceRight();

        if (Input.GetKeyDown(KeyCode.UpArrow))
            ChangeScale(multiplier: 2f);

        if (Input.GetKeyDown(KeyCode.DownArrow))
            ChangeScale(multiplier: 0.5f);
    }

    private void AddForceRight()
    {
        rigidBody.AddForce(Vector2.right * forceAmount, ForceMode2D.Impulse) ;
    }

    private void ChangeScale(float multiplier)
    {
        transform.localScale = transform.localScale * multiplier;
        rigidBody.mass *= multiplier;
    }




}
