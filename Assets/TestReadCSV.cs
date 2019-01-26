using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestReadCSV : MonoBehaviour
{
     void Awake() {
        List<Dictionary<string,object>> data = CSVReader.Read ("Markers3_converted");
        for(var i=0; i < data.Count; i++) {
            print(data[i]["TimeStamp"]);
        }
 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
