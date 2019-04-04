using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#region manager
public class Manager : MonoBehaviour
{
    //Song selected
    public static Music currentsong;
    //control audio font
    public AudioSource audioSource;
    //For Multiplayer
    //public List<Player> currentplayers = new List<Player>();
    //players points
    public int points;
    //To play
    List<int> cordinate = new List<int>();
    List<float> beattime = new List<float>();
    void Start()
    {
        audioSource.playOnAwake = false;
        //listener.loop = false;
        GameState.controlstate = GameState.State.Waiting;
    }
    void FixedUpdate()
    {
        if (GameState.controlstate == GameState.State.playing)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.UnPause();
            }
            Debug.Log("Playing a song");
        }
        else if (GameState.controlstate == GameState.State.paused)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
        }
        else if (GameState.controlstate == GameState.State.recording)
        {
            audioSource.Play();
        }
        else if (GameState.controlstate == GameState.State.resetsong)
        {
            audioSource.Stop();
            LoadSong(currentsong);
            //method to restart positions and points
        }
        else if (GameState.controlstate == GameState.State.Waiting || MemoryCard.SaveControl == MemoryCard.SaveMode.loadrecording)
        {
        }
    }
    void Finishedplaying()
    {
        Debug.Log("SavingPlayerData");
        MemoryCard.SaveControl = MemoryCard.SaveMode.Saving;
        Music.ChangePoint(points, currentsong, Player.currentplayer);
        GameState.controlstate = GameState.State.Waiting;
    }
    void LoadSong(Music music)
    {
        Debug.Log("loadingSongData");
        MemoryCard.SaveControl = MemoryCard.SaveMode.loadrecording;
        currentsong = music;
        audioSource.clip = currentsong.song;
        cordinate.Clear();
        beattime.Clear();
        cordinate = music.cordinate;
        beattime = music.beattime;
        int pointsloading = Player.currentplayer.musicsplayed[music.songID];
        music.points = pointsloading;
        MemoryCard.SaveControl = MemoryCard.SaveMode.playmode;
        GameState.controlstate = GameState.State.playing;
    }
}
#endregion