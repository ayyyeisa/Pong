/// <summary>
/// 
/// File: GameManager
/// Author: Isa Luluquisin
/// Date: November 8, 2023
/// 
/// Description: This controls the scoring and end scene.
/// 
/// </summary>
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private TMP_Text scoreText;
    private int p1Score;
    private int p2Score;

    [SerializeField] private GameObject endScene;
    [SerializeField] private TMP_Text endGameText;

    public InputController InputControllerInstance;
    public BallController BallControllerInstance;

    #endregion

    public void Start()
    {
        scoreText.text = "0 - 0";
    }

    public void Update()
    {
        //cheat code to bring a score up to 4
        if (Input.GetKeyDown((KeyCode.X)))
        {
            p1Score = 3;
            p2Score = 3;
            UpdateP1Score();
            UpdateP2Score();
        }
    }

    public void UpdateP1Score()
    {
        p1Score += 1;
        scoreText.text = p1Score + " - " + p2Score;
        if(p1Score == 5)
        {
            endGameText.text = "Player 1 Wins! <br> Press ENTER to restart the game.";
            EndGame();
        }
    }

    public void UpdateP2Score()
    {
        p2Score += 1;
        scoreText.text = p1Score + " - " + p2Score;
        if (p2Score == 5)
        {
            endGameText.text = "Player 2 Wins! <br> Press ENTER to restart the game.";
            EndGame();
        }
    }

    private void EndGame()
    {
        endScene.gameObject.SetActive(true);
        InputControllerInstance.GameEnded = true;
        InputControllerInstance.ReceivingGameInputs = false;

    }

}
