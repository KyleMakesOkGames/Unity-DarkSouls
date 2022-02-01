using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KA
{
    public class CharacterManager : MonoBehaviour
    {
        public Transform lockOnTransform;
        public CriticalDamageCollider backStabCollider;
        public CriticalDamageCollider riposteCollider;

        public int pendingCriticalDamage;

        [Header("Combat Flags")]
        public bool canBeRiposted;
        public bool isParrying;
        public bool canBeParried;
    }
}
