using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Gamestate
public class GameState : MonoBehaviour
{
    //ONLY ONE STATE CONTROL IN THE ALL CODE
    //PAYATTENTION
    public enum State { playing, paused, recording, resetsong, Waiting };
    public static State controlstate;
}
#endregion

