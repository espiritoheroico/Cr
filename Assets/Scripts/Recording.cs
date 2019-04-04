using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region RecordingSystem
public class Recording : MonoBehaviour
{
    //objects
    [SerializeField]List<int> Cordinates = new List<int>();
    //list of times
    [SerializeField]List<float> beating = new List<float>();
    int currentnumber;
    float currenttime;

    // Update is called once per frame
    void Update()
    {
        currenttime = Timer.timerControl;
        if (GameState.controlstate == GameState.State.recording)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                Rec(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Rec(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Rec(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Rec(3);
            }
        }
        else if (GameState.controlstate == GameState.State.paused)
        {
            //pause rec
        }
        else if (GameState.controlstate == GameState.State.resetsong)
        {
            Cordinates.Clear();
            beating.Clear();
            MemoryCard.SaveControl = MemoryCard.SaveMode.loading;
        }
    }
    void Rec(int number)
    {
        currentnumber = number;
        Cordinates.Add(currentnumber);
        beating.Add(currenttime);
    }
    void FinishedRecording()
    {
        Manager.currentsong.cordinate = Cordinates;
        Manager.currentsong.beattime = beating;
        MemoryCard.SaveControl = MemoryCard.SaveMode.savingrecording;
    }
}
#endregion