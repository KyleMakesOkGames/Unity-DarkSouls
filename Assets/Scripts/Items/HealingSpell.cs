using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KA
{
    [CreateAssetMenu(menuName = "Spells/Healing Spell")]
    public class HealingSpell : SpellItem
    {
        public int healAmount;

        public override void AttemptToCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats)
        {
            GameObject instantiatedWarmUpSpellFX = Instantiate(spellWarmUpFX, animatorHandler.transform);
            animatorHandler.PlayTargetAnimation(spellAnimation, true);
            Debug.Log("Attempting To Cast Spell...");
        }

        public override void SuccessfullyCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats)
        {
            GameObject instantiatedSpellFX = Instantiate(spellCastFX, animatorHandler.transform);
            playerStats.currentHealth = playerStats.currentHealth + healAmount;
            Debug.Log("Spell Cast Successful!");
        }
    }
}