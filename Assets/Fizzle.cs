using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fizzle : MonoBehaviour
{
    Movement mov;
    public float delay; //seconds to wait before fizzle
    // Start is called before the first frame update
    void Start()
    {
        mov = GetComponent<Movement>();
        print(Easing.Elastic.Out(0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SwipeZone")
        {
            print("entered!!!");
            StartCoroutine("FizzleOut");
        }
    }

    IEnumerator FizzleOut(){
        Vector3 ls=transform.localScale;
        yield return new WaitForSeconds(delay);
        float frameRate = 0.0008f;
        bool animating = true;
        float iterator = 1f;
        float decayRate = 0.001f;
        while(animating){
            float expand = Easing.Elastic.Out(iterator);
            iterator -= 0.01f;
            transform.localScale = new Vector3(ls.x*expand,ls.y*expand,0f);
            yield return new WaitForSeconds(frameRate);
            // print("iter: "+expand);
            if(iterator<=0f){
                animating=false;
                Destroy(gameObject);
            }
        }
    }
}
