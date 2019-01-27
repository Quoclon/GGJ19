using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        int scoreZoneLayer = 8;

        if (collision.gameObject.layer != scoreZoneLayer)
        {
            if (gameObject.tag == collision.tag && collision.GetComponent<NoteStats>().hasCollided == false)
            {
                collision.GetComponent<NoteStats>().scored = true;
                collision.GetComponent<NoteStats>().hasCollided = true;
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                Debug.Log("Scored with color: " + collision.GetInstanceID());   
            }
            if (gameObject.tag != collision.tag && collision.GetComponent<NoteStats>().hasCollided == false)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                //Debug.Log("NOT Scored with color: " + gameObject.tag);
            }
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().color = originalColor;
        Destroy(collision.gameObject);
    }
}
