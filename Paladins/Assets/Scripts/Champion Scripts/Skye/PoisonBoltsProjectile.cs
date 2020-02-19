using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBoltsProjectile : Projectile
{
    public float poisonBoltsLifetime = 3f;
    public float damageAmountPerSecond = 10f;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable enemy = other.GetComponent<IDamageable>();
        if (enemy != null)
            StartCoroutine(TakeDamage(enemy));
    }

    IEnumerator TakeDamage(IDamageable enemy)
    {
        for (float i = 0; i < poisonBoltsLifetime; i += 0.5f)
        {
            enemy.TakeDamage(damageAmountPerSecond);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
