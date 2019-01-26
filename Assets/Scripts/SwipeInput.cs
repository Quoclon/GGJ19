using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeInput : MonoBehaviour
{
    //float touchStartTime, touchFinishTime, timeInterval;
    Vector2 startPos, endPos, direction;
    float swipeForce;

    // Start is called before the first frame update
    void Start()
    {
        swipeForce = 50f;
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void CheckSwipe()
    {
        CheckMouse();
        CheckTouch();
    }

    private void CheckTouch()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            StartSwipe(Input.GetTouch(0).position);
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            EndSwipe(Input.GetTouch(0).position);
            ApplySwipe();
        }
    }

    private void CheckMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSwipe(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            EndSwipe(Input.mousePosition);
            ApplySwipe();     
        }
    }

    private void ApplySwipe()
    {
        gameObject.GetComponent<Movement>().SwipeForce(-direction.normalized * swipeForce);
    }

    //End of one swipe could be considered the start of another swipe??
    private void StartSwipe(Vector2 pos)
    {
        startPos = pos;
        //touchStartTime = Time.time;
    }

    private void EndSwipe(Vector2 pos)
    {
        endPos = pos;
        direction = startPos - endPos;
        //touchFinishTime = Time.time;
        //timeInterval = touchFinishTime - touchStartTime;
    }

}
