using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNotes : MonoBehaviour
{
    //---------------------------------------------------------
    // generates a list of notes from a CSV file
    //---------------------------------------------------------

    public string csvFileName;


    [HideInInspector]
    public List<Dictionary<string,int>> notes = new List<Dictionary<string, int>>();
    public float dspStartTime; 

    void Awake() {
        List<Dictionary<string,object>> data = CSVReader.Read (csvFileName);
        for(var i=0; i < data.Count; i++) {
            notes.Add(new Dictionary<string,int>() {
                {"TimeStamp", (int)data[i]["TimeStamp"]}, 
                {"NoteType", (int)data[i]["NoteType"]}
            });
        }
 
    }
    // Start is called before the first frame update
    void Start()
    {
        dspStartTime = (float)AudioSettings.dspTime;
        AudioSource audSource = GetComponent<AudioSource>();
        audSource.Play();
        print(dspStartTime);
    }

}
