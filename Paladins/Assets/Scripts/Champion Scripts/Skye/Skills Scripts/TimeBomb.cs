using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBomb : Skills
{
    
    public TimeBombProjectile timeBombPrefab;
    public Transform timeBombInstantiatePos;

    private Camera mainCamera;


    protected override void Start()
    {
        base.Start();
        mainCamera = Camera.main;
    }

    protected override void Update()
    {
        base.Update();
    }



    public override void Activate()
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 100))
        {
            TimeBombProjectile timeBomb = Instantiate(timeBombPrefab, timeBombInstantiatePos.position, Quaternion.identity) as TimeBombProjectile;
            timeBomb.ThrowBomb(hit.point, 1f);
        }
    }

    public override void Deactivate()
    {
        
    }
}
