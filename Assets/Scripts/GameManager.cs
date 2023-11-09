/// <summary>
/// 
/// File: GameManager
/// Author: Isa Luluquisin
/// Date: November 8, 2023
/// 
/// Description: This controls the game's UI system.
/// 
/// </summary>
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private TMP_Text scoreText;
    private int p1Score;
    private int p2Score;

    [SerializeField] private TMP_Text endGameText;

    #endregion

    public void Start()
    {
        scoreText.text = "0 - 0";
    }

    public void UpdateP1Score()
    {
        p1Score += 1;
        scoreText.text = p1Score + " - " + p2Score;
        if(p1Score >= 5)
        {
            endGameText.text = "Player 1 Wins! <br> Press space to restart the game.";
            endGameText.gameObject.SetActive(true);
        }
    }

    public void UpdateP2Score()
    {
        p2Score += 1;
        scoreText.text = p1Score + " - " + p2Score;
        if (p1Score >= 5)
        {
            endGameText.text = "Player 2 Wins! <br> Press enter to restart the game.";
            endGameText.gameObject.SetActive(true);
        }
    }
}
