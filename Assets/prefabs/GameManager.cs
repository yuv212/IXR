using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public Text highScoreText;
    public InputField highScoreInput;
    public bool gameOver;
    public GameObject gameoverpanel;
    public GameObject loadlevelpanel;
    public int numberOfBricks;
    public Transform[] levels;        // for level increase
    public int currentLevelIndex = 0;
    //public Rigidbody2D rb;
    //public Transform ballbridge;
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("Bricks").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLives (int changeInlives)   // this function is using the update method of lives in each level till the game over is not going to pop up
    {
        lives += changeInlives;
        if(lives <=0)
        {
            lives = 0;
            GameOver();
        }
        // check for no lives left and trigger the end of the game 
        livesText.text = " Lives:" + lives;
    }
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
    public void UpdateNumberOfBricks()        // using array function to list the elements which include number of levels (shown in game manager )
    {
        numberOfBricks--;
        if(numberOfBricks <= 0)
        {
            if (currentLevelIndex >= levels.Length - 1)      //for 1st level ... second ... third and so on .....
            {
                GameOver();
            }
            else          // for start second level in the game
            {
                loadlevelpanel.SetActive(true);        // while loading second level panel
                loadlevelpanel.GetComponentInChildren<Text>().text = "Next level" + (currentLevelIndex + 2);         // for printing level index 
                gameOver = true;
               
                Invoke("LoadLevel", 3f);        // for calling the function in future means our next level wil be load after 3 secs. that have mention
            }
        
        }
        
    }
    void LoadLevel()
    {
        //rb.velocity = Vector2.zero;
        //rb.position = ballbridge.position;
        currentLevelIndex++;
        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        numberOfBricks = GameObject.FindGameObjectsWithTag("Bricks").Length;   // loading levels when bricks will be zero shown in game manager panel 
        gameOver = false;
        loadlevelpanel.SetActive(false);

    }
    void GameOver()   // game over panel where game over text will be shown 
    {
        gameOver = true;
        gameoverpanel.SetActive(true);
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");   // high score text box included when gets game over 
        if(score < highScore)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);

            highScoreText.text = "NEW HIGH SCORE" + "\n" + "ENTER YOUR NAME BELOW.";
            highScoreInput.gameObject.SetActive(true);
        }
        else
        {
            highScoreText.text = "HIGH SCORE" + highScore+ "\n" + "can you beat it?";
        }
    }

    //public void newhighscore()
    //{
    //    string highScoreName = highScoreInput.text;
    //    PlayerPrefs.SetString("HIGHSCORENAME", highScoreName);
    //    highScoreInput.gameObject.SetActive(false);
    //    highScoreText.text = "Congratulations" + "\n" + "your new high score  is " + score;
    //}
    public void PlayAgain()      // game over panel include two buttons using (Ui text) where this one is for play again option 
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()   // this is the another option of quiting the game ...
    {
        //Application.Quit();
        SceneManager.LoadScene("Start Menu");
        Debug.Log("Game Quit");
    }
}
