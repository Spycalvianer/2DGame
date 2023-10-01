using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int playerLife;
    public float playerStamina;
    [HideInInspector] public float maxStamina;
    [HideInInspector] public float maxHealth;
    PlayerMechanics mechanics;
    public float playerStaminaRegenMult;


    private void Start()
    {
        maxStamina = playerStamina;
        maxHealth = playerLife;
        mechanics = GetComponent<PlayerMechanics>();
    }
    private void Update()
    {
        StaminaRegen();
        StaminaLost();
        Mathf.Clamp(playerStamina, -5, maxStamina);
    }
    public void PlayerDamaged(int damage)
    {
        playerLife -= damage;
    }
    public void StaminaCost(int staminaCost)
    {
        playerStamina -= staminaCost;
    }
    public void HidingStaminaCost(int hidingStaminaCost)
    {
        playerStamina -= hidingStaminaCost * Time.deltaTime;
    }
    void StaminaRegen()
    {
        if(playerStamina < maxStamina) playerStamina += Time.deltaTime * playerStaminaRegenMult;
    }
    void StaminaLost()
    {
        if(playerStamina < 0)
        {
            mechanics.movementSpeed = 0;
            mechanics.canPerformAction = false;
        }
        else
        {
            mechanics.movementSpeed = mechanics.startMovementSpeed;
            mechanics.canPerformAction = true;
        }
    }
    /*void StaminaLost()
{
    if (playerStamina <= 0)
    {
        mechanics.movementSpeed = 0;
        mechanics.canPerformAction = false;
        StartCoroutine(Timer());
    }
    else timer = 0;
}
IEnumerator Timer()
{
    timer += Time.deltaTime;
    Debug.Log(timer);
    if (timer > 3)
    {
        mechanics.canPerformAction = true;
        mechanics.movementSpeed = mechanics.startMovementSpeed;
        yield return null;
    }
}*/
}
