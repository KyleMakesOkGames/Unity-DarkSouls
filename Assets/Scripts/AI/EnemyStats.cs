using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KA
{
    public class EnemyStats : CharacterStats
    {
        EnemyAnimatorHandler enemyAnimatorHandler;

        private void Awake()
        {
            enemyAnimatorHandler = GetComponentInChildren<EnemyAnimatorHandler>();
        }

        private void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (isDead)
                return;

            currentHealth = currentHealth - damage;

            enemyAnimatorHandler.PlayTargetAnimation("Damage", true);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                enemyAnimatorHandler.PlayTargetAnimation("Dead", true);
                isDead = true;
            }
        }
    }
}