using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{

    public Slider slider;
    Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        img.color = new Color(1f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value<0.25f){
            float modulate = Mathf.Sin(Time.time*Mathf.PI)*0.25f+0.25f;
            img.color = new Color(1f*modulate,0.5f*modulate,0.5f*modulate);
        }
        else if(slider.value <0.8f){
            float modulate = Mathf.Sin(Time.time*Mathf.PI*0.5f)*0.1f+0.5f;
            img.color = new Color(0.8f-slider.value*modulate,1f*modulate,slider.value*modulate);
        }
        else if(slider.value>=1.0f){
            float Hz = 2f;
            float R = Mathf.Sin(Time.time*Mathf.PI*Hz)*0.25f+0.50f;
            float G = Mathf.Sin(Time.time*Mathf.PI*Hz+2f)*0.25f+0.50f;
            float B = Mathf.Sin(Time.time*Mathf.PI*Hz+4f)*0.25f+0.50f;
            img.color = new Color(R,G,B);
                
        }
    }
}
