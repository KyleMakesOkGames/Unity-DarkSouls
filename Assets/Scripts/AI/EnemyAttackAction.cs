using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KA
{
    [CreateAssetMenu(menuName = "AI/Enemy Actions/ Attack Action")]
    public class EnemyAttackAction : EnemyAction
    {
        public bool canCombo;

        public EnemyAttackAction comboAction;

        public int attackScore = 3;
        public float recoveryTime;

        public float maximumAttackAngle = 35f;
        public float minimumAttackAngle = -35f;

        public float minimumDistanceNeededToAttack = 0;
        public float maximumDistanceNeededToAttack = 3;

    }
}