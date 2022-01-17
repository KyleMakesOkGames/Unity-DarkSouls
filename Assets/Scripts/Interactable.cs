using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KA
{
    public class Interactable : MonoBehaviour
    {
        public float radius;
        public string interactableText;
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        public virtual void Interact(PlayerManager playerManager)
        {
            
        }
    }
}
