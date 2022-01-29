using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KA
{
    public class EnemyAnimatorHandler : AnimatorManager
    {
        public EnemyLocomotion enemyLocomotion;
        EnemyStats enemyStats;
        public EnemyManager enemyManager;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            enemyLocomotion = GetComponentInParent<EnemyLocomotion>();
            enemyStats = GetComponentInParent<EnemyStats>();
        }

        public override void TakeCriticalDamageAnimationEvent()
        {
            enemyStats.TakeDamageNoAnimation(enemyManager.pendingCriticalDamage);
            enemyManager.pendingCriticalDamage = 0;
        }

        public void AwardSoulsOnDeath()
        {
            PlayerStats playerStats = FindObjectOfType<PlayerStats>();
            SoulCountBar soulCountBar = FindObjectOfType<SoulCountBar>();

            if (playerStats != null)
            {
                playerStats.AddSouls(enemyStats.soulsAwardedOnDeath);

                if (soulCountBar != null)
                {
                    soulCountBar.SetSoulCountText(playerStats.soulCount);
                }
            }
        }

        private void OnAnimatorMove()
        {
            float delta = Time.deltaTime;
            enemyManager.enemyRigidBody.drag = 0;
            Vector3 deltaPosition = anim.deltaPosition;
            deltaPosition.y = 0;
            Vector3 velocity = deltaPosition / delta;
            enemyManager.enemyRigidBody.velocity = velocity;
        }
    }
}