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
    public bool gameOver;
    public GameObject gameoverpanel;
    public int numberOfBricks;
    public Transform[] levels;        // for level increase
    public int currentLevelIndex = 0;
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
    public void UpdateLives (int changeInlives )
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
    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if(numberOfBricks <= 0)
        {
            if (currentLevelIndex >= levels.Length - 1)  //for 1st level
            {
                GameOver();
            }
            else     // for start second level in the game
            {
                gameOver = true;
               
                Invoke("LoadLevel", 3f);   // for calling the function in future
            }
        
        }
        
    }
    void LoadLevel()
    {
        currentLevelIndex++;
        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        numberOfBricks = GameObject.FindGameObjectsWithTag("Bricks").Length;
        gameOver = false;
    }
    void GameOver()
    {
        gameOver = true;
        gameoverpanel.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
