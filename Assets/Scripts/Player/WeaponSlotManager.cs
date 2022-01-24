using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KA
{
    public class WeaponSlotManager : MonoBehaviour
    {
        private PlayerManager playerManager;

        WeaponSlotHolder leftHandSlot;
        WeaponSlotHolder rightHandSlot;
        WeaponSlotHolder backSlot;

        DamageCollider leftHandDamageCollider;
        DamageCollider rightHandDamageCollider;

        public WeaponItem attackingWeapon;

        private Animator animator;

        private QuickSlotsUI quickSlotsUI;

        private PlayerStats playerStats;
        InputHandler inputHandler;

        private void Awake()
        {
            playerManager = GetComponentInParent<PlayerManager>();
            animator = GetComponent<Animator>();

            quickSlotsUI = FindObjectOfType<QuickSlotsUI>();

            playerStats = GetComponentInParent<PlayerStats>();

            inputHandler = GetComponentInParent<InputHandler>();

            WeaponSlotHolder[] weaponHolderSlots = GetComponentsInChildren<WeaponSlotHolder>();
            foreach (WeaponSlotHolder weaponSlot in weaponHolderSlots)
            {
                if (weaponSlot.isLeftHandSlot)
                {
                    leftHandSlot = weaponSlot;
                }
                else if (weaponSlot.isRightHandSlot)
                {
                    rightHandSlot = weaponSlot;
                }
                else if(weaponSlot.isBackSlot)
                {
                    backSlot = weaponSlot;
                }
            }
        }

        public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
        {
            if (isLeft)
            {
                leftHandSlot.currentWeapon = weaponItem;
                leftHandSlot.LoadWeaponModel(weaponItem);
                LoadLeftWeaponDamageCollider();
                quickSlotsUI.UpdateWeaponQuickSlotsUI(true, weaponItem);
                #region Handle Left Weapon Idle Animations
                if (weaponItem != null)
                {
                    animator.CrossFade(weaponItem.left_Hand_Idle, 0.2f);
                }
                else
                {
                    animator.CrossFade("Left Arm Empty", 0.2f);
                }
                #endregion
            }
            else
            {
                if (inputHandler.twoHandFlag)
                {
                    backSlot.LoadWeaponModel(leftHandSlot.currentWeapon);
                    leftHandSlot.UnloadWeaponAndDestroy();
                    animator.CrossFade(weaponItem.TH_Idle, 0.2f);
                }
                else
                {
                    #region Handle Right Weapon Idle Animations

                    animator.CrossFade("Both Arms Empty", 0.2f);
                    backSlot.UnloadWeaponAndDestroy();
                    if (weaponItem != null)
                    {
                        animator.CrossFade(weaponItem.right_Hand_Idle, 0.2f);
                    }
                    else
                    {
                        animator.CrossFade("Right Arm Empty", 0.2f);
                    }
                    #endregion
                }
                rightHandSlot.currentWeapon = weaponItem;
                rightHandSlot.LoadWeaponModel(weaponItem);
                LoadRightWeaponDamageCollider();
                quickSlotsUI.UpdateWeaponQuickSlotsUI(false, weaponItem);
            }
        }

        #region Handle Weapon Damage Colliders
        private void LoadLeftWeaponDamageCollider()
        {
            leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }

        private void LoadRightWeaponDamageCollider()
        {
            rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }

        public void OpenDamageCollider()
        {
            if(playerManager.isUsingRightHand)
            {
                rightHandDamageCollider.EnableDamageCollider();
            }
            else if(playerManager.isUsingLeftHand)
            {
                leftHandDamageCollider.EnableDamageCollider();
            }
        }

        public void CloseDamageCollider()
        {
            rightHandDamageCollider.DisableDamageCollider();
        }
        #endregion

        public void DrainStaminaLightAttack()
        {
            playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.lightAttackMultiplier));
        }

        public void DrainStaminaHeavyAttack()
        {
            playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.heavyAttackMultiplier));
        }
    }
}
