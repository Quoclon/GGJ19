using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateTextWithValue : MonoBehaviour
{
    TextMeshProUGUI textmeshPro;
    int value;
    ScoreManager scoreManager;

    //public GameObject scoreContainer;
    // Start is called before the first frame update
    void Start()
    {
        textmeshPro = GetComponent<TextMeshProUGUI>();
        print("tmp: "+textmeshPro);

        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        //==============================================\\
        // !!! uncomment and replace link w/ appropriate var

        //value = scoreContainer.VARIABLE_NAME_HERE;
        value = scoreManager.comboCount;
        Debug.Log("TEEEST: " + value);
        //==============================================//

    }

    // Update is called once per frame
    void Update()
    {
        value = scoreManager.comboCount;
        textmeshPro.SetText("{0}",value);
    }
}
