using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    public GameObject playerBullet;

    public static Prefabs instance;
    private void Awake()
    {
        instance = this;
    }
}
