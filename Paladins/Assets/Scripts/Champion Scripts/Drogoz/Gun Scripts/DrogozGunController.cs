using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrogozGunController : MonoBehaviour
{
    public Transform gunHold;
    public DrogozGun startingGun;
    public bool salvoActivated = false;

    private DrogozGun equipedGun;


    void Start()
    {
        if (startingGun != null)
            GunToEquip(startingGun);
    }

    void Update()
    {

    }

    public void PrimaryShoot()
    {
        if (!salvoActivated)
            equipedGun.PrimaryShoot();
        else
            StartCoroutine("ShootSalvo");
    }

    public void ShootRightClick()
    {
        equipedGun.RightClickShoot();
    }

    private IEnumerator ShootSalvo()
    {
        for (int i = 0; i < 3; i++)
        {
            equipedGun.PrimaryShoot();
            yield return new WaitForSeconds(0.1f);
        }

        salvoActivated = false;
    }

    public void GunToEquip(Gun gunToEquip)
    {
        if (equipedGun != null)
            Destroy(equipedGun.gameObject);

        equipedGun = Instantiate(gunToEquip, gunHold.position, gunHold.rotation) as DrogozGun;
        equipedGun.transform.parent = gunHold;
    }
}
