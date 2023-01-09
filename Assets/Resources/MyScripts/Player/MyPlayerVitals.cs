using UnityEngine;
using UnityEngine.UI;

public class MyPlayerVitals : MonoBehaviour
{
    public float maxHealth = 100f;
    public float maxStamina = 100f;
    private float currentHealth;
    public Slider healthSlider;
    public Slider staminaSlider;

    public static MyPlayerVitals instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public float Health
    {
        get { return currentHealth; }
        set
        {
            currentHealth = Mathf.Clamp(value, 0f, maxHealth);
            healthSlider.value = currentHealth / maxHealth;
            if (currentHealth == 0)
            {
                Debug.Log("Player is dead!");
            }
        }
    }
    public float MaxStamina
    {
        get { return maxStamina; }
    }

    public void UpdateStaminaSlider(float currentStamina)
    {
        staminaSlider.value = currentStamina;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        staminaSlider.maxValue = maxStamina;
    }
}
