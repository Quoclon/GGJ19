using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    //---------------------------------------------------------
    // instantiates notes compiled from GenerateNotes
    //---------------------------------------------------------
    
    public GameObject note;
    public int noteSpacing; // How long each note is falling down the screen. Lower vals = faster.
    GenerateNotes generateNotes;
    AudioSource audSource;
    public int currentSampleTime; // keeps track of current place in music, in samples

    List<Dictionary<string,int>> notes; // a list containg notes, their type, and sample to appear
    int totalNotes;
    int currentNoteIndex;
    float nextSample;
    public Vector2 spawnPos; // will spawn at this node's position unless otherwise specified

    Vector2 removePos;

    // Start is called before the first frame update
    void Start()
    {
        if(!(spawnPos==null)){
            spawnPos=(Vector2)transform.position;
        }

        removePos = (Vector2)GameObject.Find("SwipeZone").transform.position;

        audSource = GetComponent<AudioSource>();
        generateNotes = GetComponent<GenerateNotes>();
        notes = generateNotes.notes;

        totalNotes = notes.Count;
        currentNoteIndex = 0;
        print("total notes: "+totalNotes);

        nextSample = notes[currentNoteIndex]["TimeStamp"];


        for (int i = 0; i < notes.Count; i++)
        {
            GameObject n = Instantiate(note, spawnPos, Quaternion.identity);
            Movement mov = n.GetComponent<Movement>();
            mov.hitSample = notes[i]["TimeStamp"];
            mov.removePos = removePos;
            mov.spacing = noteSpacing;

        }
    }



    // Update is called once per frame
    void Update()
    {
        currentSampleTime = audSource.timeSamples;
        
        // if((audSource.timeSamples >= nextSample) && (currentNoteIndex < totalNotes)){
        //     Instantiate(note,transform.position,Quaternion.identity);
        //     currentNoteIndex++;
        //     nextSample = notes[Mathf.Min(currentNoteIndex,totalNotes-1)]["TimeStamp"];

        // }
    }
}
