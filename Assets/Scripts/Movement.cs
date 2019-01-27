using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private SwipeInput swipeinput;
    private float moveSpeed;
    public bool isSwiped;
    public bool canSwipe;
    public int hitSample; // sample to make contact with swipearea
    public float interpoRange;

    [HideInInspector]
    public int spacing; // how many samples each note is on the screen for. Lower vals = faster. 
                        // controlled in NoteSpawner
    public Vector2 spawnPos;
    public Vector2 removePos;
    NoteSpawner noteSpawner;


    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        noteSpawner = GameObject.Find("Spawner").GetComponent<NoteSpawner>();
        swipeinput = GetComponent<SwipeInput>();
        isSwiped = false;
        canSwipe = false;
        moveSpeed = -0.50f;
    }

    // Update is called once per frame
    void Update()
    {
        float posInterpolate = (spacing - (hitSample-noteSpawner.currentSampleTime)) / (float)spacing;
        interpoRange = posInterpolate;
        if(!isSwiped){
            transform.position = Vector2.Lerp(
                spawnPos,
                removePos,
                posInterpolate
            );
        }
        // if(!isSwiped)
        // {
        //     transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        // }

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
            print("ontriggerenter: "+collision.name);
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
