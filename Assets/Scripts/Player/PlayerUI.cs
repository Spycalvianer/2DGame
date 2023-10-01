using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image staminaImage;
    public Image healthImage;
    PlayerData data;
    private void Awake()
    {
        data = GetComponent<PlayerData>();
    }
    void Update()
    {
        UpdateStats();
    }
    void UpdateStats()
    {
        staminaImage.fillAmount = data.playerStamina/data.maxStamina;
        healthImage.fillAmount = data.playerLife / data.maxHealth;
    }
}
