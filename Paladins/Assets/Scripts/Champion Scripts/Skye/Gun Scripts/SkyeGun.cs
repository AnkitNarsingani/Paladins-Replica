using UnityEngine;

public class SkyeGun : Gun
{
    public Projectile poisonBolts;

    public void RightClickShoot()
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 100))
        {
            Projectile projectile = Instantiate(poisonBolts, muzzle.position, Quaternion.identity) as Projectile;
            projectile.SetDirection(hit.point - projectile.transform.position);
            projectile.SetSpeed(muzzleVelocity);

            IDamageable enemy = hit.collider.GetComponent<IDamageable>();
            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount);
            }
        }
        else
        {
            Projectile projectile = Instantiate(poisonBolts, muzzle.position, muzzle.rotation) as Projectile;
            projectile.SetSpeed(muzzleVelocity);
        }
    }
}
