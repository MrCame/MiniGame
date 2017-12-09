﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float enemyMaxHealth;
    public Slider enemyHealthBar;
    private float currentHealth;

    // Use this for initialization
    void Start () {
        currentHealth = enemyMaxHealth;
        enemyHealthBar.maxValue = enemyMaxHealth;
        enemyHealthBar.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void takeDamage(float damage)
    {
        enemyHealthBar.gameObject.SetActive(true);
        currentHealth -= damage;
        enemyHealthBar.value = currentHealth;
        if (currentHealth <= 0)
        {
            if (GetComponentInChildren<EnemySlimDamage>() != null)
            {
                EnemySlimDamage esd = GetComponentInChildren<EnemySlimDamage>();
                if (esd.pc != null)
                {
                    esd.pc.caught = false;
                    esd.pc.setspeed(new Vector2(0, 0));
                }
            }
            onDead();
        }
    }

    private void onDead()
    {
        Destroy(gameObject);
    }
}
