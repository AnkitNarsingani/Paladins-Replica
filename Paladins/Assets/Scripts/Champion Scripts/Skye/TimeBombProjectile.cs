using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBombProjectile : MonoBehaviour
{
    public float bombRadius = 15f;
    public float timeToExplode = 5f;
    public float damageAmount = 1000f;
    public float gravity = 11f;

    private float timer = 0f;

    void Update()
    {
        if (timer > timeToExplode)
            Explode();

        timer += Time.deltaTime;
    }

    public void ThrowBomb(Vector3 targetPos, float time)
    {
        Vector3 Vo = CalculateVelocity(targetPos, transform.position, 1f);
        transform.rotation = Quaternion.LookRotation(Vo);
        GetComponent<Rigidbody>().velocity = Vo;
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;

        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(gravity) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y *= Vy;

        return result;
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, bombRadius);

        foreach (Collider c in colliders)
        {
            if (c.CompareTag("Enemy"))
            {
                if (Physics.Raycast(transform.position, c.transform.position - transform.position, out RaycastHit hit, bombRadius))
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
