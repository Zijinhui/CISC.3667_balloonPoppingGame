using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{

    [SerializeField] int score = 0;
    [SerializeField] int level = 1;
    [SerializeField] int value = 10;
    const int DEFAULT_POINTS = 1;
    [SerializeField] Text scoreTxt;
    [SerializeField] Text levelTxt;
    [SerializeField] Text nameTxt;
    

    // Start is called before the first frame update
    void Start()
    {
        // Level_1 Scene locates at index 3
        level = SceneManager.GetActiveScene().buildIndex - 2;
        score = PersistentData.Instance.GetScore();

        //display score
        DisplayScore();
        //display level
        DisplayLevel();
        //display name
        DisplayName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int addend) {
        score += addend;
        Debug.Log("score " + score);
        DisplayScore();

        //update current score to global score
        PersistentData.Instance.SetScore(score);
    }

    public void UpdateScore() {
        UpdateScore(value);
    }

    public void ChangeValue() {
        //avoid negative score
        if(value > 0) {
            value -= 1;
        }     
    }

    public void DisplayScore() {
        scoreTxt.text = "Score: " + score;
    }

    public void DisplayLevel() {
        levelTxt.text = "Level: " + level;
    }

     public void DisplayName()
    {
        nameTxt.text = "Player: " + PersistentData.Instance.GetName();
    }

}
