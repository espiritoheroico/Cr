using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void PauseGame()
    {
        GameState.controlstate = GameState.State.paused;
    }

    public void SaveRecord()
    {
        MemoryCard.SaveControl = MemoryCard.SaveMode.savingrecording;
    }

    public void SaveProgress()
    {
        MemoryCard.SaveControl = MemoryCard.SaveMode.Saving;
    }

    public void ResetSong()
    {
        GameState.controlstate = GameState.State.resetsong;
    }

    public void Playsong()
    {
        GameState.controlstate = GameState.State.playing;
    }

    public void RecordSong()
    {
        GameState.controlstate = GameState.State.recording;
    }
}
