using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ChampionController : MonoBehaviour
{
    private CharacterController characterController;
    
    private Camera playerCamera;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
        playerCamera = Camera.main;
    }

    void Update()
    {
        
    }

    public void Move(Vector3 velocity)
    {
        characterController.Move(velocity * Time.deltaTime);
    }

    public void LookAt(Vector3 dir)
    {
        playerCamera.transform.localRotation = Quaternion.Euler(dir.x, 0f, 0f);
        transform.Rotate(Vector3.up * dir.y);
    }
}
