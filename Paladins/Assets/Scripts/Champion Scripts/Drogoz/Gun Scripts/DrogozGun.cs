using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrogozGun : Gun
{
    public Projectile primaryBullets;
    public Projectile fireSpit;

    public override void PrimaryShoot()
    {
        if (nextShotTime > msBetweenShots / 1000)
        {
            Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 10))
            {
                Projectile projectile = Instantiate(primaryBullets, muzzle.position, muzzle.rotation) as Projectile;
                projectile.SetDirection(Vector3.Normalize(hit.point - projectile.transform.position));
                projectile.SetSpeed(muzzleVelocity);
            }

        }
    }

    public void RightClickShoot()
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 999))
        {
            Projectile projectile = Instantiate(fireSpit, Camera.main.transform.position, Quaternion.identity) as Projectile;
            projectile.SetDirection(Vector3.Normalize(hit.point - projectile.transform.position));
            projectile.SetSpeed(3.5f);

            IDamageable enemy = hit.collider.GetComponent<IDamageable>();
            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount);
            }
        }
        else
        {
            //Projectile projectile = Instantiate(poisonBolts, muzzle.position, muzzle.rotation) as Projectile;
            //projectile.SetSpeed(muzzleVelocity);
        }
    }
}
