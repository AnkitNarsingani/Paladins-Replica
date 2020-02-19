using UnityEngine;

public class SkyeGunController : MonoBehaviour
{
    public Transform gunHold;
    public SkyeGun startingGun;
    private SkyeGun equipedGun;

    private void Start()
    {
        if (startingGun != null)
            GunToEquip(startingGun);
    }

    public void PrimaryShoot()
    {
        equipedGun.PrimaryShoot();
    }

    public void ShootRightClick()
    {
        equipedGun.RightClickShoot();
    }

    public SkyeGun GetEquipedGun()
    {
        return equipedGun;
    }

    public void GunToEquip(Gun gunToEquip)
    {
        if (equipedGun != null)
            Destroy(equipedGun.gameObject);

        equipedGun = Instantiate(gunToEquip, gunHold.position, gunHold.rotation) as SkyeGun;
        equipedGun.transform.parent = gunHold;
    }
}
