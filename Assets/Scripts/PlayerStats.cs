using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KA
{
    public class PlayerStats : MonoBehaviour
    {
        public int healthLevel;
        public int maxHealth;
        public int currentHealth;

        public int staminaLevel;
        public int maxStamina;
        public int currentStamina;

        public HealthBar healthBar;

        AnimatorHandler animatorHandler;

        private void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            animatorHandler = GetComponentInChildren<AnimatorHandler>();

            maxStamina = SetMaxStaminaFromStaminaLevel();
            currentStamina = maxStamina;
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        private int SetMaxStaminaFromStaminaLevel()
        {
            maxStamina = staminaLevel * 10;
            return maxStamina;
        }

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;

            healthBar.SetCurrentHealth(currentHealth);

            animatorHandler.PlayTargetAnimation("Damage", true);

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                animatorHandler.PlayTargetAnimation("Dead", true);
            }
        }

        public void TakeStaminaDamage(int damage)
        {
            currentStamina = currentStamina - damage;
        }
    }
}
