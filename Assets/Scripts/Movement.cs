using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private SwipeInput swipeinput;
    public bool isSwiped;
    public bool canSwipe;
    public int hitSample; // sample to make contact with swipearea
    public float interpoRange;
    public float NoteDeathTimer;

    [HideInInspector]
    public int spacing; // how many samples each note is on the screen for. Lower vals = faster. 
                        // controlled in NoteSpawner
    public Vector2 spawnPos;
    public Vector2 removePos;
    NoteSpawner noteSpawner;
    ScoreManager scoreManager;


    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        noteSpawner = GameObject.Find("Spawner").GetComponent<NoteSpawner>();
        swipeinput = GetComponent<SwipeInput>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();


        NoteDeathTimer = 10000f;
        isSwiped = false;
        canSwipe = false;
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

        if (canSwipe)
        {
            swipeinput.CheckSwipe();
        }

        if(canSwipe && !isSwiped)
        {
            StartCoroutine(DestroyNote(NoteDeathTimer));
        }
    }

    //Called from SwipeInput.cs
    public void SwipeForce(Vector2 swipeDirection)
    {
        isSwiped = true;
        canSwipe = false;
        GetComponent<Rigidbody2D>().AddForce(swipeDirection);
    }

    //Checks when Note enters the "SwipeZone" in the centre of the screen
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SwipeZone")
        {
            canSwipe = true;
        }
    }

    //Checks when Note exits the "SwipeZone" in the centre of the screen
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SwipeZone")
        {
            canSwipe = false;
        }
    }


    IEnumerator DestroyNote(float delay)
    {
        if (delay != 0)
        {
            yield return new WaitForSeconds(delay);
            if (!isSwiped)
            {
                scoreManager.ResetComboCount();
                Destroy(gameObject);
            }
        }
            
    }



}
