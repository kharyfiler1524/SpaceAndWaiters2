using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiter : MonoBehaviour
{
    int pointReward;
    float lowerYLimit;
    ScoreController scoreController;
    WaiterAnchor waiterAnchor;

    private void Awake()
    {
        lowerYLimit = -4.9f;
        pointReward = 50;
    }

    private void Start()
    {
        scoreController = ScoreController.instance;
        waiterAnchor = WaiterAnchor.instance;

        waiterAnchor.RegisterActiveWaiter(this);
    }

    private void Update()
    {
        if(transform.position.y <= lowerYLimit)
        {
            scoreController.LossSplash();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            scoreController.UpdateScore(pointReward);
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);

            waiterAnchor.RemoveWaiter(this);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
