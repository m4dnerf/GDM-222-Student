using JetBrains.Annotations;
using UnityEngine;

public class PlayerPrefData : MonoBehaviour
{
    public string playerName = "Unknown";
    public int highscore = 0;
    public float volume = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        SavedataPlayer();
    }
    public void SavedataPlayer()
    {
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("HighScore", highscore);
        PlayerPrefs.SetFloat("Volume", volume);

        PlayerPrefs.Save();
        Debug.Log("Save Player data");
    }

    private void LoadDataPlayer()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playerName = PlayerPrefs.GetString("PlayerName", "No name");
            highscore = PlayerPrefs.GetInt("Highscore", 0);
            volume = PlayerPrefs.GetFloat("Volume", 1.0f);
            Debug.Log("Load Player Data Successful");

        }
        else
        {
            Debug.Log("Not found data");
        }
    }
    public void ResetData()
    {

    }
    
}
