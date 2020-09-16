using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float bulletSpeed;
    float bulletYLimit;

    private void Awake()
    {
        bulletYLimit = 5.5f;
        bulletSpeed = 4f;
    }

    void Update()
    {
        transform.position += Vector3.up * bulletSpeed * Time.deltaTime;

        if(transform.position.y > bulletYLimit)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
