using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives:" + lives;
        scoreText.text = "score:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLives (int changeInlives )
    {
        lives += changeInlives;
        // check for no lives left and trigger the end of the game 
        livesText.text = " Lives:" + lives;
    }
}
