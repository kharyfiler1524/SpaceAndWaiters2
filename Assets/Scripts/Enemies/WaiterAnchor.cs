using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterAnchor : MonoBehaviour
{
    bool isMovingRight;
    float shimmySpeed;
    float forwardUnitLength;
    float forwardLerpDuration;
    float xShimmyLimit;    
    Vector3 startPosition;
    List<Waiter> activeWaiters = new List<Waiter>();
    ScoreController scoreController;

    public static WaiterAnchor instance;
    private void Awake()
    {
        instance = this;

        forwardLerpDuration = 0.1f;
        shimmySpeed = 0.2f;
        forwardUnitLength = 0.2f;
        xShimmyLimit = 0.81f;
    }

    void Start()
    {
        scoreController = ScoreController.instance;

        startPosition = transform.position;    
    }

    void Update()
    {
        ShimmyTowardsPlayer();
    }

    void ShimmyTowardsPlayer()
    {
        // Move left until -xShimmyLimit
        // Lerp forward one unit
        // Move right until xShimmyLimit
        if(transform.position.x <= -xShimmyLimit && !isMovingRight) { isMovingRight = true; StartCoroutine(LerpForwardOneUnit()); }

        if(transform.position.x >= xShimmyLimit && isMovingRight) { isMovingRight = false; StartCoroutine(LerpForwardOneUnit()); }

        float movementUnit = shimmySpeed * Time.deltaTime;
        if (!isMovingRight)
        {
            transform.position += Vector3.left * movementUnit;
        }
        else
        {
            transform.position += Vector3.right * movementUnit;
        }

    }

    IEnumerator LerpForwardOneUnit()
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y - forwardUnitLength, transform.position.z);
        while (time < forwardLerpDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / forwardLerpDuration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

    public void RegisterActiveWaiter(Waiter waiterToAdd)
    {
        activeWaiters.Add(waiterToAdd);
    }

    public void RemoveWaiter(Waiter waiterToRemove)
    {
        activeWaiters.Remove(waiterToRemove);
        if(activeWaiters.Count <= 0)
        {            
            scoreController.VictorySplash();
        }
    }
}
