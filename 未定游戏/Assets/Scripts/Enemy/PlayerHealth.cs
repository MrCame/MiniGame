using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float PlayerMaxHealth;
    public GameObject deathFX;
    public Slider PlayerHealthBar;

    public float damagePerSecond = 0.01f;

    private PlayerAudio PlayerAudio;

    [HideInInspector]public float currentHealth;

    // Use this for initialization
    void Start()
    {
        currentHealth = PlayerMaxHealth;
        PlayerHealthBar.maxValue = PlayerMaxHealth;
        PlayerHealthBar.value = currentHealth;
        PlayerAudio = FindObjectOfType<PlayerAudio>();
    }

    // Update is called once per frame
    void Update()
    {
        takeDamage(damagePerSecond);
    }

    public void takeDamage(float damage)
    {
        if (damage > 5)
            PlayerAudio.MakeAudio(0, false, false, true);
        PlayerHealthBar.gameObject.SetActive(true);
        currentHealth -= damage;
        PlayerHealthBar.value = currentHealth;
        if (currentHealth <= 0)
            onDead();
    }

    private void onDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        ResourceManager.Instance().gameMenuCtr.ShowFailPanel();
    }
}
