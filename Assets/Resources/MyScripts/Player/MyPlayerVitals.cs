using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class MyPlayerVitals : MonoBehaviour
{
    public float maxHealth = 100f;
    public float maxStamina = 100f;
    private float currentHealth;
    public Slider healthSlider;
    public Slider staminaSlider;
    [SerializeField] PlayableDirector damageSequence;

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

    private float previousHealth;
    public float Health
    {
    get { return currentHealth; }
    set
    {
        previousHealth = currentHealth;
        currentHealth = Mathf.Clamp(value, 0f, maxHealth);
        healthSlider.value = currentHealth;
        if (currentHealth == 0)
        {
            Debug.Log("Player is dead!");
        }
        if (currentHealth < previousHealth)
        {
            damageSequence.Play();
        }
        else if (currentHealth > previousHealth)
        {
            Debug.Log("Player gained health!");
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
