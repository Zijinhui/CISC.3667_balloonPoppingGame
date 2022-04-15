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
        //scoreTxt = this.GetComponent<Text>();
        level = SceneManager.GetActiveScene().buildIndex;
        score = PersistentData.Instance.GetScore();

        //display score
        DisplayScore();
        //display score
        DisplayLevel();
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
        value -= 1;
    }

    public void DisplayScore() {
        scoreTxt.text = "Score: " + score;
    }

    public void DisplayLevel() {
        levelTxt.text = "Level: " + level;
    }

     public void DisplayName()
    {
        //nameTxt.text = "Hi, " + PersistentData.Instance.GetName();
    }

}
