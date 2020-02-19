using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skills : MonoBehaviour
{
    public bool IsActivated { get; protected set; }
    public float cooldownTime = 2f;
    public float skillDuration = 0f;

    protected static GameObject player;
    protected float timer = 0;

    public abstract void Activate();
    public abstract void Deactivate();

    protected virtual void Start()
    {
        player = FindObjectOfType<Champion>().gameObject;
        timer = cooldownTime;
    }

    protected virtual void Update()
    {
        if(IsActivated)
        {
            if (timer > skillDuration)
                Deactivate();
        }

        timer += Time.deltaTime;
    }
}
