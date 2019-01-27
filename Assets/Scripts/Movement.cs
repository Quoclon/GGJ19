using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private SwipeInput swipeinput; 
    private float moveSpeed;
    public bool isSwiped;
    public bool canSwipe;
    

    // Start is called before the first frame update
    void Start()
    {
        swipeinput = GetComponent<SwipeInput>();
        isSwiped = false;
        canSwipe = false;
        moveSpeed = -0.50f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSwiped)
        {
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        }

        if (canSwipe)
        {
            swipeinput.CheckSwipe();
        }
    }

    //Called from SwipeInput.cs
    public void SwipeForce(Vector2 swipeDirection)
    {
        isSwiped = true;
        canSwipe = false;
        GetComponent<Rigidbody2D>().AddForce(swipeDirection);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SwipeZone")
        {
            canSwipe = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SwipeZone")
        {
            canSwipe = false;
        }
    }
    
}
