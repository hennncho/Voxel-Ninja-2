using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text healthAmountText;
    [SerializeField] private TMP_Text projectilesAmountText;
    [SerializeField] private Image healthBar;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerRangeAttack playerRangeAttack;

    private void Update()
    {
        healthAmountText.text = playerHealth.currentHP.ToString();
        healthBar.fillAmount = playerHealth.currentHP / playerHealth.maxHP;
        projectilesAmountText.text = playerRangeAttack.currentAmmo.ToString();
    }


}
