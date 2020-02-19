using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalDestroy : MonoBehaviour
{
    public float decalTime;

    float timer = 0;

    void Update()
    {
        if(timer > decalTime)
        {
            Destroy(gameObject);
        }

        timer += Time.deltaTime;
    }
}
