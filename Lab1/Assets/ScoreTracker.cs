using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{

    [SerializeField] int score = 0;
    const int DEFAULT_POINTS = 1;
    [SerializeField] Text scoreTxt;
    

    // Start is called before the first frame update
    void Start()
    {
        //scoreTxt = this.GetComponent<Text>();
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int addend) {
        score += addend;
        Debug.Log("score " + score);
        //display score
        DisplayScore();
    }

    public void UpdateScore() {
        UpdateScore(DEFAULT_POINTS);
    }

    public void DisplayScore() {
        scoreTxt.text = "Score: " + score;
    }

}
