using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevelZone : MonoBehaviour
{
    public Action EndOfLevelReachedEvent;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") == false)
            return;

        Rigidbody2D rigidBody = collider.gameObject.GetComponent<Rigidbody2D>();

        if (rigidBody == null)
            return;

        if(rigidBody.velocity.magnitude < 0.5f)
        {
            Debug.Log("End of level reached.");
            EndOfLevelReachedEvent?.Invoke();
        }
            
    }
}
