using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KA
{
    public class DamageCollider : MonoBehaviour
    {
        public CharacterManager characterManager;

        Collider damageCollider;

        public int currentWeaponDamage = 30;

        private void Awake()
        {
            damageCollider = GetComponent<Collider>();
            damageCollider.gameObject.SetActive(true);
            damageCollider.isTrigger = true;
            damageCollider.enabled = false;
        }

        public void EnableDamageCollider()
        {
            damageCollider.enabled = true;
        }

        public void DisableDamageCollider()
        {
            if(damageCollider != null)
            {
                damageCollider.enabled = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                PlayerStats playerStats = other.GetComponent<PlayerStats>();
                CharacterManager enemyCharacterManager = other.GetComponent<CharacterManager>();

                if(enemyCharacterManager != null)
                {
                    if(enemyCharacterManager.isParrying)
                    {
                        characterManager.GetComponentInChildren<AnimatorManager>().PlayTargetAnimation("Parried", true);
                        return;
                    }
                }

                if(playerStats != null)
                {
                    playerStats.TakeDamage(currentWeaponDamage);
                }
            }

            if(other.tag == "Enemy")
            {
                Debug.Log("Hit");
                EnemyStats enemyStats = other.GetComponent<EnemyStats>();
                CharacterManager enemyCharacterManager = other.GetComponent<CharacterManager>();

                if (enemyCharacterManager != null)
                {
                    if (enemyCharacterManager.isParrying)
                    {
                        characterManager.GetComponentInChildren<AnimatorManager>().PlayTargetAnimation("Parried", true);
                        return;
                    }
                }

                if (enemyStats != null)
                {
                    enemyStats.TakeDamage(currentWeaponDamage);
                }
            }
        }
    }
}
