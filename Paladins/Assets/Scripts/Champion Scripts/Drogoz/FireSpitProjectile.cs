using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpitProjectile : MonoBehaviour
{
    public float fireSpitRadius = 15f;
    public float damageAmount = 700f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, fireSpitRadius);

        foreach (Collider c in colliders)
        {
            if (c.CompareTag("Enemy"))
            {
                if (Physics.Raycast(transform.position, c.transform.position - transform.position, out RaycastHit hit, fireSpitRadius))
                {
                    IDamageable damagable = hit.collider.GetComponent<IDamageable>();
                    if (damagable != null) damagable.TakeDamage(damageAmount);
                }
            }
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Projectile>() != null)
            Explode();
        else
            Destroy(gameObject);
    }
}
