using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBomb : Skills
{
    public float smokeBombRadius;
    public Material defaultMaterial;
    public Material invisibleMaterial;

    public bool isInvisible = false;
    public bool smokeBombActive = false;

    private Vector3 smokeBombOrigin = Vector3.positiveInfinity;
    private SkyeGunController gunController;

    protected override void Start()
    {
        base.Start();
        gunController = player.GetComponent<SkyeGunController>();
    }

    protected override void Update()
    {
        base.Update();

        if (IsActivated)
        {
            if (smokeBombActive)
            {
                if (Vector3.Distance(player.transform.position, smokeBombOrigin) > smokeBombRadius)
                    isInvisible = false;
                else if (Vector3.Distance(player.transform.position, smokeBombOrigin) < smokeBombRadius)
                    isInvisible = true;
            }

            ChangeMaterial();
        }
    }

    public override void Activate()
    {
        if (timer > cooldownTime)
        {
            IsActivated = true;
            smokeBombOrigin = player.transform.position;
            isInvisible = true;
            smokeBombActive = true;
            ChangeMaterial();
            timer = 0;
        }
    }

    public override void Deactivate()
    {
        IsActivated = false;
        smokeBombActive = false;
        isInvisible = false;
        ChangeMaterial();
        timer = 0;
    }

    private void ChangeMaterial()
    {
        if (isInvisible)
        {
            for (int i = 0; i < gunController.GetEquipedGun().transform.childCount; i++)
            {
                MeshRenderer meshRenderer = gunController.GetEquipedGun().transform.GetChild(i).GetComponent<MeshRenderer>();
                if (meshRenderer != null)
                    meshRenderer.material = invisibleMaterial;
            }
        }
        else
        {
            for (int i = 0; i < gunController.GetEquipedGun().transform.childCount; i++)
            {
                MeshRenderer meshRenderer = gunController.GetEquipedGun().transform.GetChild(i).GetComponent<MeshRenderer>();
                if (meshRenderer != null)
                    meshRenderer.material = defaultMaterial;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(smokeBombOrigin, smokeBombRadius);
    }
}
