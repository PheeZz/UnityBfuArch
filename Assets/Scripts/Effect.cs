using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public float effectTimeToLive = 2;

    void Awake()
    {
        Destroy(gameObject, effectTimeToLive);
    }
}
