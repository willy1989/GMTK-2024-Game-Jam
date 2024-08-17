using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleModifierInstantaneous : MonoBehaviour
{
    [SerializeField] private float multiplier;

    private void ApplyScaleModifier(Rigidbody2D rigidBody)
    {
        rigidBody.mass *= multiplier;

        Vector3 currentScale = rigidBody.transform.localScale;

        Vector3 newScale = new Vector3(currentScale.x * multiplier, currentScale.y * multiplier, currentScale.z * multiplier);

        rigidBody.transform.localScale = newScale;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") == false)
            return;
        
        Rigidbody2D rigidBody = collider.GetComponent<Rigidbody2D>();

        if (rigidBody != null)
            ApplyScaleModifier(rigidBody);
    }
}
