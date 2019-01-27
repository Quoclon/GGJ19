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
        Sprite[] sprites;

        switch (randNum)
        {
            
            case 0:
                gameObject.tag = "Blue";
                sprites = Resources.LoadAll<Sprite>("Bad");
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case 1:
                gameObject.tag = "Green";
                sprites = Resources.LoadAll<Sprite>("Bad_2");
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case 2:
                gameObject.tag = "Yellow";
                sprites = Resources.LoadAll<Sprite>("Z");
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
        }

        /*
        switch (randNum)
        {
            case 0:
                gameObject.tag = "Blue";
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
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
        */

    }
}
