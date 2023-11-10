/*****************************************************************************
// File Name : GameManager.cs
// Author : Isa Luluquisin
// Creation Date : November 8, 2023
//
// Brief Description : This controls the scording and end scene.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables
    [Header("Variables affecting scoring:")]
    [SerializeField] private TMP_Text scoreText;
    private int p1Score;
    private int p2Score;

    [Header("References to the end screen and text")]
    [SerializeField] private GameObject endScene;
    [SerializeField] private TMP_Text endGameText;

    [Tooltip("References to game objects. Used to disable scripts")]
    public InputController InputControllerInstance;
    public BallController BallControllerInstance;

    #endregion

    public void Start()
    {
        scoreText.text = "0 - 0";
    }

    /// <summary>
    /// Increases player1's score by 1. If the score reaches 5, it announces that player1 
    /// won and that the game is over. EndGame function is also called to reset game
    /// </summary>
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

    /// <summary>
    /// Increases player2's score by 1. If the score reaches 5, it announces that player2
    /// won and that the game is over. EndGame function is also called to reset game
    /// </summary>
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

    /// <summary>
    /// Set the game over scene active so players can see the text and who won.
    /// This function also sets certain boolean variables so that players cannot 
    /// move their paddles or launch the ball. They must start the game over
    /// </summary>
    private void EndGame()
    {
        endScene.gameObject.SetActive(true);

        //prevents player from moving game objects. They may only restart game
        InputControllerInstance.GameEnded = true;
        InputControllerInstance.ReceivingGameInputs = false; 

    }

}
