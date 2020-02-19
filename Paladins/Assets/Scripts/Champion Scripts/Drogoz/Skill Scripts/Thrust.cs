using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrust : Skills
{
    public float forwardThrust = 10f;
    public float upwardsThrust = 20f;

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
            player.GetComponent<Drogoz>().Thrust(player.transform.forward * 10 + player.transform.up * 20);
            timer = 0f;
            IsActivated = true;
        }
    }

    public override void Deactivate()
    {
        IsActivated = false;
        timer = 0;
    }
}
