using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drogoz : Champion
{
    protected DrogozGunController gunController;
    public bool isUsingUltimate = false;

    protected override void Start()
    {
        base.Start();
        gunController = GetComponent<DrogozGunController>();
    }

    protected override void Update()
    {
        if(isUsingUltimate)
        {
            Look();
            Vector3 move = Camera.main.transform.forward * 20;
            championController.Move(move);
        }
        else
        {
            base.Update();
        }
    }

    protected override void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetButton("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
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

    public void Thrust(Vector3 force)
    {
        velocity += force;
    }
}