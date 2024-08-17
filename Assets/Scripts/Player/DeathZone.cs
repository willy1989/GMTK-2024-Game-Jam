using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") == false)
            return;

        PlayerDeath playerDeath = collider.GetComponent<PlayerDeath>();

        if(playerDeath != null )
            playerDeath.KillPlayer();
    }
}
