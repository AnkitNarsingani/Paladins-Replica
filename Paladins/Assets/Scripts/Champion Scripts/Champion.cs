using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ChampionController))]
public abstract class Champion : MonoBehaviour, IDamageable
{
    [Space]
    [Space]
    [Header("Champion")]
    public float health = 100f;

    [Header("Movement")]
    public float walkSpeed = 10f;
    public float gravity = -9.98f;
    public float jumpHeight = 10f;

    [Space]
    [Space]
    [Header("Mouse")]
    public float mouseSensitivity = 100f;
    public Vector3 currentRotation;

    [Space]
    [Space]
    [Header("Shoot")]
    public bool isGunAuto;

    [Space]
    [Space]
    [Header("Jump")]
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    [Space]
    [Space]
    [Header("Events")]
    public GameEvent OnQActivation;
    public GameEvent OnFActivation;
    public GameEvent OnRightClickActivation;
    public GameEvent OnUltimateActivation;

    protected ChampionController championController;
    protected Vector3 velocity;
    protected bool isGrounded;

    protected abstract void Shoot();
    protected abstract void RightMouseClick();
    protected abstract void QClick();
    protected abstract void FClick();
    protected abstract void Ultimate();

    protected virtual void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        championController = GetComponent<ChampionController>();
    }

    protected virtual void Update()
    {
        Walk();
        Jump();
        Look();
        TakeInput();

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        if (velocity.x != 0 || velocity.z != 0)
        {
            velocity.x = 0;
            velocity.z = 0;
        }
    }

    protected void Walk()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        championController.Move(move * walkSpeed);

        velocity.y += gravity * Time.deltaTime;

        championController.Move(velocity);
    }

    protected void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        currentRotation.x -= mouseY;
        currentRotation.x = Mathf.Clamp(currentRotation.x, -90f, 90f);

        currentRotation.y = (currentRotation.y + mouseX) % 360;

        championController.LookAt(new Vector3(currentRotation.x, mouseX));
    }

    protected void TakeInput()
    {
        if (Input.GetMouseButton(0) && isGunAuto)
            Shoot();
        else if (Input.GetMouseButtonDown(0) && !isGunAuto)
            Shoot();
        else if (Input.GetMouseButtonDown(1))
            RightMouseClick();
        else if (Input.GetKeyDown(KeyCode.Q))
            QClick();
        else if (Input.GetKeyDown(KeyCode.F))
            FClick();
        else if (Input.GetKeyDown(KeyCode.E))
            Ultimate();
    }

    protected virtual void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }

    public virtual void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
    }
}
