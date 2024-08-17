using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Action playerDeathEvent;

    public void KillPlayer()
    {
        Destroy(gameObject);
        playerDeathEvent?.Invoke();
    }
}
