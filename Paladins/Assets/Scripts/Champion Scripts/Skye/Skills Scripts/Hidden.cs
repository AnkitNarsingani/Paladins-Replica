using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidden : Skills
{
    public Material defaultMaterial;
    public Material invisibleMaterial;

    public bool isInvisible = false;

    private Material currentMaterial;

    private SkyeGunController gunController;

    protected override void Start()
    {
        base.Start();      
        gunController = player.GetComponent<SkyeGunController>();
        currentMaterial = gunController.transform.GetChild(0).GetComponent<Material>();
    }

    protected override void Update()
    {
        base.Update();

        if (IsActivated)
        {
            ChangeMaterial();
        }
    }

    public override void Activate()
    {
        if (timer > cooldownTime)
        {
            IsActivated = true;
            isInvisible = true;
            ChangeMaterial();
            timer = 0f;
        }
    }

    public override void Deactivate()
    {
        IsActivated = false;
        isInvisible = false;
        ChangeMaterial();
        timer = 0f;
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
}
