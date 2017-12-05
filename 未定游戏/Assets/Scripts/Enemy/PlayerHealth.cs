using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float PlayerMaxHealth;
    public GameObject deathFX;
    public Slider PlayerHealthBar;
    public AudioSource hit;
    [HideInInspector]public float currentHealth;

    // Use this for initialization
    void Start()
    {
        currentHealth = PlayerMaxHealth;
        PlayerHealthBar.maxValue = PlayerMaxHealth;
        PlayerHealthBar.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(float damage)
    {
        PlayerHealthBar.gameObject.SetActive(true);
        currentHealth -= damage;
        PlayerHealthBar.value = currentHealth;
        hit.Play();
        if (currentHealth <= 0)
            onDead();
    }

    private void onDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
