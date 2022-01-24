using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KA
{
    public class SpellItem : MonoBehaviour
    {
        public GameObject spellWarmUpFX;
        public GameObject spellCastFX;
        public string spellAnimation;

        [Header("Spell Type")]
        public bool isFaithSpell;
        public bool isMagicSpell;
        public bool isPyroSpell;

        [Header("Spell Description")]
        [TextArea]
        public string spellDescription;

        public virtual void AttemptToCastSpell()
        {
            Debug.Log("Attempted To Cast Spell");
        }

        public virtual void SuccessfullyCastSpell()
        {
            Debug.Log("You Casted A Spell Successfully");
        }
    }
}
