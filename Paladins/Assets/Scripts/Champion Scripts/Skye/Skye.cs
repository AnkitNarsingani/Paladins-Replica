using UnityEngine;

public class Skye : Champion
{
    protected SkyeGunController gunController;

    protected override void Start()
    {
        base.Start();
        gunController = GetComponent<SkyeGunController>();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FClick()
    {
        OnFActivation.Raise();
    }

    protected override void QClick()
    {
        OnQActivation.Raise();
    }

    protected override void Shoot()
    {
        gunController.PrimaryShoot();
    }

    protected override void RightMouseClick()
    {
        OnRightClickActivation.Raise();
    }

    protected override void Ultimate()
    {
        OnUltimateActivation.Raise();
    }
}
