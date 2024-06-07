using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    int multiplier = 1;
    public int streak = 0;

    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("RockMeter", 25);
        PlayerPrefs.SetInt("NotesHit", 1);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {

    }

    public void AddStreak()
    {
        if (PlayerPrefs.GetInt("RockMeter") + 1 < 50)
            PlayerPrefs.SetInt("RockMeter", PlayerPrefs.GetInt("RockMeter") + 3);//
        PlayerPrefs.Save();
        streak += 1;
        Debug.Log(streak);
        if (streak >= 24)
            multiplier = 4;
        else if (streak >= 16)
            multiplier = 3;
        else if (streak >= 8)
            multiplier = 2;
        else
            multiplier = 1;


        PlayerPrefs.SetInt("NoteHit", PlayerPrefs.GetInt("NoteHit") + 1);

        UpdateGUI();
    }

    public void ResetStreak()
    {

        PlayerPrefs.SetInt("RockMeter", PlayerPrefs.GetInt("RockMeter") - 2);
        if (PlayerPrefs.GetInt("RockMeter") < 0)
            Lose();
        streak = 0;
        multiplier = 1;
        UpdateGUI();
    }

    void Lose()
    {
            if (PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("Score"))
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"))
            ;
        SceneManager.LoadScene(9);
    }

    public void Win()
    {
            if (PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("Score"))
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"))
            ;
        SceneManager.LoadScene("ScoreScene");
    }
    void UpdateGUI()
    {
        // PlayerPrefs.SetInt("Streak",streak);
        // PlayerPrefs.SetInt("Mult",multiplier);
    }

    public int GetScore()
    {
        return 100 * multiplier;
    }
}