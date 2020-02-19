using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salvo : Skills
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
            player.GetComponent<DrogozGunController>().salvoActivated = true;
            timer = 0f;
        }
    }

    public override void Deactivate()
    {
        IsActivated = false;
        timer = 0f;
    }
}
