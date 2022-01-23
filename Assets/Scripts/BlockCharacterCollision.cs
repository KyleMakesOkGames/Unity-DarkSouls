using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KA
{
    public class BlockCharacterCollision : MonoBehaviour
    {
        public CapsuleCollider characterCollider;
        public CapsuleCollider collisionIgnoreCollider;

        private void Awake()
        {
            Physics.IgnoreCollision(characterCollider, collisionIgnoreCollider, true);
        }
    }
}
