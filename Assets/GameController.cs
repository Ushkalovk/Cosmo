using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public UnityEngine.UI.Text scoreLabel;
    public UnityEngine.UI.Text healthLabel;
    public GameObject gameOverPanel;

    public int score = 0;
    
    public static GameController instance;
    void Start()
    {
        instance = this;
    }
    
    void Update()
    {
        scoreLabel.text = "Score: " + score;
        healthLabel.text = "Health: " + PlayerScript.instance.health;
    }
}
