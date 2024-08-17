using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonLevelPiece : MonoBehaviour
{
    [SerializeField] private Collider2D baseCollider2D;

    [SerializeField] private Rigidbody2D buttonRigidBody;

    [SerializeField] private UnityEvent triggeredAction;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider == baseCollider2D)
        {
            buttonRigidBody.bodyType = RigidbodyType2D.Static;
            triggeredAction?.Invoke();
        }
    }

}
