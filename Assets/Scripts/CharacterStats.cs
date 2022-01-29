using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KA
{
    public class CharacterStats : MonoBehaviour
    {
        public int healthLevel;
        public int maxHealth;
        public int currentHealth;

        public int staminaLevel;
        public int maxStamina;
        public float currentStamina;

        public int focusLevel;
        public float maxFocusPoints;
        public float currentFocusPoints;

        public int soulCount = 0;

        public bool isDead;
    }
}
