using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleModifier : MonoBehaviour
{
    private void ChangeScale(Rigidbody2D rigidBody)
    {
        rigidBody.mass *= 2f;

        Vector3 currentScale = rigidBody.transform.localScale;

        Vector3 newScale = new Vector3(currentScale.x * 2f, currentScale.y * 2f, currentScale.z * 2f);

        rigidBody.transform.localScale = newScale;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") == false)
            return;
        
        Rigidbody2D rigidBody = collider.GetComponent<Rigidbody2D>();

        if (rigidBody != null)
            ChangeScale(rigidBody);
    }
}
