using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipe : MonoBehaviour
{

    Vector2 startPos, endPos;
    public float direction;
    float touchStartTime, touchFinishTime, timeInterval;
    bool canSwipe = false;
 


    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //checkInputMouse();
        //checkInputTouch();

        if(Input.GetMouseButtonDown(0))
        {
            if (canSwipe)
            {
                touchStartTime = Time.time;
                startPos = Input.mousePosition;
                Debug.Log("touch start");
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            if (canSwipe)
            {
                touchFinishTime = Time.time;
                endPos = Input.mousePosition;
                Debug.Log("touch end");

                timeInterval = touchFinishTime - touchStartTime;
                direction = -(startPos.x - endPos.x);
                if(direction > 0)
                {
                    direction = 0.50f;
                }
                else
                {
                    direction = -0.50f;
                }


                Debug.Log("Direction: " + direction);

            }
        }



    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered");
        canSwipe = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        canSwipe = false;
        Debug.Log("exited");
    }
}
