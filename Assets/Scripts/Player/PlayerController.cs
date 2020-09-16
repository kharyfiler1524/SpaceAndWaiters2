using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float startingBulletTimer;
    float bulletTimer;
    float lockedYPosition;

    Prefabs prefabs;

    private void Awake()
    {
        startingBulletTimer = 0.8f;
        lockedYPosition = -4.37f;
    }

    void Start()
    {
        prefabs = Prefabs.instance;
    }

    void Update()
    {
        Fire();

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            transform.position = new Vector3(touchPosition.x, lockedYPosition, 0f);

        }
    }

    void Fire()
    {
        if(bulletTimer > 0) { bulletTimer -= Time.deltaTime; return; }
        bulletTimer = startingBulletTimer;

        GameObject bullet = Instantiate(prefabs.playerBullet, transform.position, Quaternion.identity);
    }
}
