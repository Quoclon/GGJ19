using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float moveSpeed = -0.50f;
    swipe swipeDirection;

    // Start is called before the first frame update
    void Start()
    {
        swipeDirection = GetComponent<swipe>();
    }

    // Update is called once per frame
    void Update()
    {
        if(swipeDirection.direction == 0)
        {
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);

        }
        else
        {
            transform.Translate(swipeDirection.direction * Time.deltaTime, 0, 0);
        }


    }
}
