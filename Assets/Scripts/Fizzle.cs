using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fizzle : MonoBehaviour
{
    Movement mov;
    public float delay; //seconds to wait before fizzle
    Vector3 ls;

    bool animating = false;
    float iterator = 1.5f;
    float decayRate = 0.02f;

    public ScoreManager scoreManager;


    // Start is called before the first frame update
    void Start()
    {
        mov = GetComponent<Movement>();
        ls=transform.localScale;
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animating){
            float expand = Easing.Elastic.Out(iterator);
            iterator -= decayRate;
            transform.localScale = new Vector3(ls.x*expand,ls.y*expand,0f);
            // print("iter: "+expand);
            if(iterator<=0f){
                animating=false;
                scoreManager.ResetComboCount();
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SwipeZone")
        {
            animating=true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision){
        if(collision.tag == "SwipeZone")
        {
            animating=false;
            //print("EXITED");
        }

    }


}
