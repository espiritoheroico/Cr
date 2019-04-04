using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public string TimerString,Timerdate;
    public float Min,seg,mili,velocity, StartTime,distance,cronometer,timerController,pauseVar;
    //TIME
    public static float timerControl;
    //music gen
    void Start()
    {
        Debug.Log("StartingTime");
        StartTime = Time.time;
    }
    void FixedUpdate()
    {
        if (GameState.controlstate == GameState.State.playing)
        {
            Debug.Log("Time is up");
            Cronometer();
        }
        else if (GameState.controlstate == GameState.State.paused || GameState.controlstate == GameState.State.Waiting)
        {
            Debug.Log("Waiting for instructions");
            StartTime = 0;
            pauseVar = Time.time;
        }
        else if (GameState.controlstate == GameState.State.recording)
        {
            Debug.Log("Recording a song");
            //rec mode
            Cronometer();
        }
        else if (GameState.controlstate == GameState.State.resetsong)
        {
            ResetTime();
        }
    }
    //CURRENT TIME
    public void Cronometer()
    {
        timerControl = Time.time - pauseVar;
        //Debug.Log(TimerControl);
        string mins = ((int)timerControl / 60).ToString("00");
        string segs = (timerControl % 60).ToString("00");
        string milisegs = ((timerControl * 100) % 100).ToString("00");
        Timerdate = string.Format("{00}:{01}:{02}", mins, segs, milisegs);
        TimerString = string.Concat(mins, segs, milisegs);
        cronometer = int.Parse(TimerString);
        //EDIT THIS
        timerController += timerControl;
    }
    void ResetTime()
    {
        Debug.Log("resetingTime");
        Timerdate = 0.ToString();
        TimerString = 0.ToString();
        cronometer = 0;
        StartTime = Time.time - timerControl;
    }
}
