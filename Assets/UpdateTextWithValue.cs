using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateTextWithValue : MonoBehaviour
{
    TextMeshProUGUI textmeshPro;
    int value;
    public GameObject scoreContainer;
    // Start is called before the first frame update
    void Start()
    {
        textmeshPro = GetComponent<TextMeshProUGUI>();
        print("tmp: "+textmeshPro);
        //==============================================\\
        // !!! uncomment and replace link w/ appropriate var

        // value = scoreContainer.VARIABLE_NAME_HERE;
        //==============================================//

    }

    // Update is called once per frame
    void Update()
    {
        textmeshPro.SetText("{0}",value);
    }
}
