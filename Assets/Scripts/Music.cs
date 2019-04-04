using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#region Music
public class Music
{
    public int songID;
    public string songname;
    public AudioClip song;
    //Cordinate will return a Piece Number, REMEMBER THAT
    public List<int> cordinate = new List<int>();
    public List<float> beattime = new List<float>();
    public int points;
    public Player player;
    int difficult;
    public static List<Music> musiccreated = new List<Music>();
    /// <summary>
    /// Create a NEW SONG
    /// </summary>
    public static void Createsong(AudioClip music, string songname, List<int> c, List<float> b, int d)
    {
        //create a song using a construct method
        Music musictocreate = new Music();
        musictocreate.songID = musiccreated.Count;
        musictocreate.song = music;
        musictocreate.songname = songname;
        musictocreate.cordinate = c;
        musictocreate.beattime = b;
        musictocreate.difficult = d;
        Music.musiccreated.Add(musictocreate);
    }
    /// <summary>
    /// Change the music points in the save slot of the music
    /// </summary>
    public static void ChangePoint(int p, Music m,Player player)
    {
        m.points = p;
        m.player = player;
        player.musicpoints[m.songID] = p;
    }
}
#endregion