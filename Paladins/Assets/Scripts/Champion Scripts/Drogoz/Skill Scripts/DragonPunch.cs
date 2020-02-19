using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPunch : Skills
{
    public Transform cameraHolder;
    public GameObject drogozModel;

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
        if (timer > cooldownTime)
        {
            player.GetComponent<Drogoz>().isUsingUltimate = true;
            mainCamera.transform.localPosition = cameraHolder.localPosition;

            for (int i = 0; i < mainCamera.transform.childCount; i++)
                mainCamera.transform.GetChild(i).gameObject.SetActive(false);

            drogozModel.SetActive(true);
            drogozModel.transform.parent = mainCamera.transform;
            IsActivated = true;
            timer = 0;
        }
    }

    public override void Deactivate()
    {
        player.GetComponent<Drogoz>().isUsingUltimate = false;
        drogozModel.transform.parent = mainCamera.transform.parent;
        drogozModel.SetActive(false);
        mainCamera.transform.localPosition = new Vector3(0, 0.7f, 0);

        for (int i = 0; i < mainCamera.transform.childCount; i++)
            mainCamera.transform.GetChild(i).gameObject.SetActive(true);

        IsActivated = false;
        timer = 0;
    }
}
