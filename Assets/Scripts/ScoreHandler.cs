using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    Color originalColor;
    ScoreManager scoreManager;
    //public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        GameObject[] scoreManagerGO = GameObject.FindGameObjectsWithTag("ScoreManager");
        scoreManager = scoreManagerGO[0].GetComponent<ScoreManager>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            scoreManager.IncreaseComboCount(1);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        int scoreZoneLayer = 8;

        if (collision.gameObject.layer != scoreZoneLayer)
        {
            if(collision.GetComponent<NoteStats>().hasCollided == false && collision.GetComponent<Movement>().isSwiped == true)
            {
                Debug.Log("Collision Tag: " + collision.tag);
                if (gameObject.tag == collision.tag)
                
                {
                    collision.GetComponent<NoteStats>().hasCollided = true;
                    scoreManager.IncreaseComboCount(1);
                    scoreManager.IncreaseSleepMeter(10);
                    Destroy(collision.gameObject);
                    //anim.SetBool("Happy", true);
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                }

                if (gameObject.tag != collision.tag)
                {
                    collision.GetComponent<NoteStats>().hasCollided = true;
                    scoreManager.ResetComboCount();
                    Destroy(collision.gameObject);
                    //anim.SetTrigger("Sad");
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().color = originalColor;
        if (collision.GetComponent<NoteStats>().hasCollided == true)
        {
            Destroy(collision.gameObject);
        }
    }
}
