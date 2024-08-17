using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleModifierGradual : MonoBehaviour
{
    [SerializeField] private float increment;

    private void ApplyScaleModifier(Rigidbody2D rigidBody)
    {
        rigidBody.mass += increment * Time.deltaTime;

        Vector3 currentScale = rigidBody.transform.localScale;

        Vector3 newScale = new Vector3(currentScale.x + increment * Time.deltaTime, currentScale.y + increment * Time.deltaTime, currentScale.z + increment * Time.deltaTime);

        rigidBody.transform.localScale = newScale;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") == false)
            return;

        Rigidbody2D rigidBody = collider.GetComponent<Rigidbody2D>();

        if (rigidBody != null)
            ApplyScaleModifier(rigidBody);
    }
}
