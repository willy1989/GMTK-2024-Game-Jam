using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform gameOverMenu;

    [SerializeField] private PlayerDeath playerDeath;

    private void Awake()
    {
        playerDeath.playerDeathEvent += () => ToggleGameOverMenu(onOff: true);
    }

    private void ToggleGameOverMenu(bool onOff)
    {
        gameOverMenu.gameObject.SetActive(onOff);
    }
}
