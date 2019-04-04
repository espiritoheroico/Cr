using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballcontroller : MonoBehaviour
{
    public GameObject ball;
    public List<GameObject> parts = new List<GameObject>();
    public float velocity;
    int currentPoint;
    void Update()
    {
        if (GameState.controlstate == GameState.State.playing)
        {
            Follow();
        }
        else
        {
            //nothing
            Debug.Log("ball paused");
        }
    }
    void Follow()
    {
        velocity = RegularVelocityCalculate(Vector2.Distance(parts[Manager.currentsong.cordinate[currentPoint]].transform.position, ball.transform.position)
           , Manager.currentsong.beattime[currentPoint]);
        transform.position = parts[Manager.currentsong.cordinate[currentPoint]].transform.position -= transform.position * velocity * Time.deltaTime;
        Aproach();
    }
    /// <summary>
    /// Return the velocity to follow Up
    /// </summary>
    public static float RegularVelocityCalculate(float distance, float time)
    {
        Debug.Log("angularVelocity");
        time = time -= Timer.timerControl;
        float v = distance / time;
        return v;
    }
    void Aproach()
    {
        if (Vector2.Distance(ball.transform.position,parts[Manager.currentsong.cordinate[currentPoint]].transform.position) <= 0.1f)
        {
            currentPoint++;
        }
        else
        {
            Follow();
        }
    }
}
