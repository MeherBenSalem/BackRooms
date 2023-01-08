using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPlayerVitals : MonoBehaviour
{
// The maximum health and stamina values
    public float maxHealth = 100f;
    public float maxStamina = 100f;

    // The current health and stamina values
    private float currentHealth;

    // The UI slider elements that display the current health and stamina values
    public Slider healthSlider;
    public Slider staminaSlider;

    // Property for getting and setting the current health value
    public float Health
    {
        get { return currentHealth; }
        set
        {
            currentHealth = Mathf.Clamp(value, 0f, maxHealth);
            // Update the health slider value
            healthSlider.value = currentHealth / maxHealth;
            // Check if the player has run out of health
            if (currentHealth == 0)
            {
                // Player is dead
                Debug.Log("Player is dead!");
            }
        }
    }
    public float MaxStamina
    {
        get { return maxStamina; }
    }

    // Property for getting and setting the current stamina value
    public void UpdateStaminaSlider(float currentStamina)
    {
        staminaSlider.value = currentStamina;
    }

    void Start()
    {
        // Set the initial values of the health and stamina
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        staminaSlider.maxValue = maxStamina;
    }
}
