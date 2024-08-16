using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceModifierGradual : MonoBehaviour
{
    [SerializeField] private Vector2 force;

    private void ApplyForceModifier(Rigidbody2D rigidBody)
    {
        rigidBody.AddForce(force * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") == false)
            return;

        Rigidbody2D rigidBody = collider.GetComponent<Rigidbody2D>();

        if (rigidBody != null)
            ApplyForceModifier(rigidBody);
    }
}
