using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class NoteStats : MonoBehaviour
{
    public bool hasCollided;
    public int score;
    

    // Start is called before the first frame update
    void Start()
    {
        hasCollided = false;
        SetNoteType();
    }

    private void SetNoteType()
    {
        int randNum = Random.Range(0, 3);

        switch (randNum)
        {
            case 0:
                gameObject.tag = "Blue";
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case 1:
                gameObject.tag = "Green";
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case 2:
                gameObject.tag = "Yellow";
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
        }
    }
}
