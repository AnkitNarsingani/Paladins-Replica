using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPunchCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(5000);
        }
        GetComponentInParent<Drogoz>().isUsingUltimate = false;
    }
}
