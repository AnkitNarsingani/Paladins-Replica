using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public Transform muzzle;
    public Projectile primaryBullet;
    public float damageAmount = 10f;
    public float msBetweenShots = 100f;
    public float muzzleVelocity = 35f;

    public GameObject decalPrefab;
    public GameObject effectPrefab;
    
    protected Camera mainCamera;

    protected float nextShotTime = 0f;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 10);
        nextShotTime += Time.deltaTime;
    }

    public virtual void PrimaryShoot()
    {
        if (nextShotTime > msBetweenShots / 1000)
        {
            Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 10))
            {
                IDamageable enemy = hit.collider.GetComponent<IDamageable>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damageAmount);
                }
                else
                {
                    //Instantiate(effectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                    Instantiate(decalPrefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                }
            }
            nextShotTime = 0;
        }
    }
}

public enum FireRate
{
    Single,
    Burst,
    Auto
}