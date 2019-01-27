using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedMeSleepPower : MonoBehaviour
{
    Slider slider;
    public GameObject sleepPower;
    
    void Start(){
        slider = GetComponent<Slider>();
    }

    void Update(){
        if(sleepPower==null){
            print("WARNING: you did not connect an object containging sleep power");
        }

        // ===========================================\\
        // !!! uncomment below and ajust as needed

        // slider.value = sleepPower.VARIABLE_CONTAINING_SLEEP_POWER
        // ===========================================//
            

    }
}

