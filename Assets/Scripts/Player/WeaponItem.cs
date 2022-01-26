using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KA
{
    [CreateAssetMenu(menuName = "Item/Weapon Item")]
    public class WeaponItem : Item
    {
        public GameObject modelPrefab;
        public bool isUnarmed;

        [Header("Idle Animations")]
        public string right_Hand_Idle;
        public string left_Hand_Idle;
        public string TH_Idle;

        [Header("One Handed Attacks")]
        public string OH_Light_Attack_1;
        public string OH_Light_Attack_2;
        public string OH_Light_Attack_3;
        public string OH_Heavy_Attack_1;
        public string OH_Heavy_Attack_2;

        [Header("Two Handed Attacks")]
        public string TH_Light_Attack_1;
        public string TH_Light_Attack_2;
        public string TH_Light_Attack_3;
        public string TH_Heavy_Attack_1;
        public string TH_Heavy_Attack_2;

        [Header("Stamina Drain Costs")]
        public int baseStamina;
        public float lightAttackMultiplier;
        public float heavyAttackMultiplier;

        [Header("Weapon Type")]
        public bool isSpellCaster;
        public bool isPyroCaster;
        public bool isFaithCaster;
        public bool isMeleeWeapon;
    }
}