using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedMeSleepPower : MonoBehaviour
{
    Slider slider;
    public GameObject sleepPower;
    public ScoreManager scoreManager;
    
    void Start(){
        slider = GetComponent<Slider>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void Update(){
        if(scoreManager == null){
            print("WARNING: you did not connect an object containging sleep power");
        }

        // ===========================================\\
        // !!! uncomment below and ajust as needed

        //slider.value = sleepPower.VARIABLE_CONTAINING_SLEEP_POWER
        slider.value = scoreManager.sleepMeterCurr;
        // ===========================================//


    }
}

