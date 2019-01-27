using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class NoteStats : MonoBehaviour
{
    public bool scored;
    public bool hasCollided;
    public int score;
    

    // Start is called before the first frame update
    void Start()
    {
        scored = false;
        hasCollided = false;
        score = 0;
        SetNoteType();

    }

    private void SetNoteType()
    {
        int randNum = Random.Range(0, 4);
        //Debug.Log(randNum);

        switch (randNum)
        {
            case 0:
                gameObject.tag = "Blue";
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case 1:
                gameObject.tag = "Magenta";
                gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
                break;
            case 2:
                gameObject.tag = "Green";
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case 3:
                gameObject.tag = "Yellow";
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
        }

        //Debug.Log("Tag Name: " + gameObject.tag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustScoreBy(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }
}
