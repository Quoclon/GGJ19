using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject note;
    GenerateNotes generateNotes;
    AudioSource audSource;

    List<Dictionary<string,int>> notes; // a list containg notes, their type, and sample to appear
    int totalNotes;
    int currentNoteIndex;
    float nextSample;


    // Start is called before the first frame update
    void Start()
    {
        audSource = GetComponent<AudioSource>();
        generateNotes = GetComponent<GenerateNotes>();
        notes = generateNotes.notes;

        totalNotes = notes.Count;
        currentNoteIndex = 0;
        print("total notes: "+totalNotes);

        nextSample = notes[currentNoteIndex]["TimeStamp"];

        // StartCoroutine("IntervalSpawn");

    }

    // todo: delete
    IEnumerator IntervalSpawn()
    {
        while(true){
            Instantiate(note,transform.position,Quaternion.identity);
            print(GetComponent<AudioSource>().timeSamples);
            yield return new WaitForSeconds(1f);

        }

    }


    // Update is called once per frame
    void Update()
    {
        if((audSource.timeSamples >= nextSample) && (currentNoteIndex < totalNotes)){
            Instantiate(note,transform.position,Quaternion.identity);
            currentNoteIndex++;
            nextSample = notes[Mathf.Min(currentNoteIndex,totalNotes-1)]["TimeStamp"];

        }
    }
}
