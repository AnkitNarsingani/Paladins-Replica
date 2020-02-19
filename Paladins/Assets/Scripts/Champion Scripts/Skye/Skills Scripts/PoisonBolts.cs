using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBolts : Skills
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Activate()
    {
        if (timer > cooldownTime)
        {
            IsActivated = true;
            player.GetComponent<SkyeGunController>().ShootRightClick();
            timer = 0f;
        }
    }

    public override void Deactivate()
    {
        IsActivated = false;
        timer = 0;
    }
}
