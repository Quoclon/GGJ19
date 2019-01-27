using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int comboCount;
    float comboBonus;
    float baseScoreIncrease;
    float score;
    float sleepMeterMax;
    float sleepMeterCurr;
    float sleepMeterBonus;
    float scoreUpdateFrequency;
    float timeCounter;

    // Start is called before the first frame update
    void Start()
    {
        comboBonus = 1.0f;
        comboCount = 0;
        baseScoreIncrease = 10;
        score = 0;
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
        Debug.Log(comboCount);
    }

    public void ResetComboCount()
    {
        comboCount = 0;
        comboBonus = 0;
        Debug.Log(comboCount);

    }

}
