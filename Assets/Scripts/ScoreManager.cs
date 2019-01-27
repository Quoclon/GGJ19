using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int comboCount;
    public float comboBonus;
    public float baseScoreIncrease;
    public float score;
    public int scoreConvertedToInt;
    public float sleepMeterMax;
    public float sleepMeterCurr;
    public float sleepMeterBonus;
    public float scoreUpdateFrequency;
    public float timeCounter;

    // Start is called before the first frame update
    void Start()
    {
        comboBonus = 1.0f;
        comboCount = 0;
        baseScoreIncrease = 10;
        score = 0;
        scoreConvertedToInt = 0;
        sleepMeterMax = 100;
        sleepMeterCurr = 0;
        sleepMeterBonus = 1;
        scoreUpdateFrequency = 0.1f;
        timeCounter = scoreUpdateFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeCounter < 0)
        {
            IncreaseScoreOverTime();
            timeCounter = scoreUpdateFrequency;
            scoreConvertedToInt = (int)score;
            //Debug.Log("Original Score: " + score);
            //Debug.Log("Converted Score: " + scoreConvertedToInt);
        }

        timeCounter -= Time.deltaTime;

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseComboCount(1);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetComboCount();
        }
        */
    }

    private void IncreaseScoreOverTime()
    {
        //comboBonus not set yet
       score += baseScoreIncrease * sleepMeterBonus * comboBonus;
       //Debug.Log("Score: " + score + " " + "sleepMeterBonus: " + " " + sleepMeterBonus + " " + "comboBonus: " + comboBonus );
    }

    public void IncreaseSleepMeter(int amount)
    {
        sleepMeterCurr = sleepMeterCurr >= sleepMeterMax ? sleepMeterMax : sleepMeterCurr + amount;
        sleepMeterBonus = 1 + sleepMeterCurr / sleepMeterMax;
        //Debug.Log("Sleep Bonus: " + sleepMeterBonus);
    }

    public void IncreaseComboCount(int amount)
    {
        comboCount += amount;
        comboBonus = 1 + (comboCount / 10);
        Debug.Log("Combo Count: " + comboCount);
    }

    public void ResetComboCount()
    {
        comboCount = 0;
        comboBonus = 0;
        sleepMeterCurr = 0;
        //Debug.Log(comboCount);
    }

}
