using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player
{
    //save in DB Player ID is a key
    public string playername;
    public string password;
    public int playerID;
    public int playeLevel;
    public int points;
    public static Player currentplayer;
    //my music record
    public List<int> musicsplayed = new List<int>();
    public List<int> musicpoints = new List<int>();}

#region Player
public class PlayerManager : MonoBehaviour
{
    //PLAYERS CREATED = PLAYER QUANT
    public List<Player> playerscreated = new List<Player>();
    //register
    [SerializeField]private TMP_InputField Usernamefield, passwordfield;
    void Start()
    {
        Usernamefield.text = "";
        passwordfield.text = "";
        Usernamefield.characterLimit = 10;
        passwordfield.characterLimit = 10;
        for (int i = 0; i < Music.musiccreated.Count; i++)
        {
            Player.currentplayer.musicsplayed[i] = Music.musiccreated[i].songID;
            //musicpoints[i] = Music.musiccreated[i].points;
        }
    }
    #region methods
    public void LevelUp(Player p)
    {
        if(p.points > 1000*p.playeLevel)
        {
            p.playeLevel++;
        }
    }

    public void CreatePlayer()
    {
        bool checkUsername = false;
        if (Usernamefield.text == "" || passwordfield.text == "")
        {
            Debug.Log("Fill all fields");
        }
        else if(Check(checkUsername)){
            Debug.Log("Name already in use");
            Usernamefield.text = "";
        }
        else
        {
            Player playercreated = new Player();
            playercreated.playername = Usernamefield.text;
            playercreated.password = passwordfield.text;
            playercreated.playeLevel = 0;
            playerscreated.Add(playercreated);
            playercreated.playerID = playerscreated.Count;
            Debug.Log("New Player Has Arrived");
        }
    }
    public void LoginPlayer()
    {
        for (int i = 0; i < playerscreated.Count; i++)
        {
            if (playerscreated[i].playername == Usernamefield.text && playerscreated[i].password == passwordfield.text)
            {
                Debug.Log("login Sucess");
                Player.currentplayer = playerscreated[i];
                Debug.Log(Player.currentplayer.playername);
                Debug.Log(playerscreated.Count+" identification " + playerscreated[i].playername);
            }
            else
            {
                Usernamefield.text = "";
                passwordfield.text = "";
            }
        }
    }
    bool Check(bool b)
    {
        for (int i = 0; i < playerscreated.Count; i++)
        {
            if (playerscreated[i].playername == Usernamefield.text)
            {
                Debug.Log("has a equal name");
                //true is on use
                b = true;
            }
            else
            {
                b = false;
            }
        }
        return b;
    }
    /// <summary>
    /// Current player, Points of music
    /// </summary>
    public void IncreasePoint(Player player, int percentpointofmusic)
    {
        player.points = (percentpointofmusic * 20)/100;
    }
    #endregion
}
#endregion