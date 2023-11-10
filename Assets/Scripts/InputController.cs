/*****************************************************************************
// File Name : InputController.cs
// Author : Isa Luluquisin
// Creation Date : October 20, 2023
//
// Brief Description : This controls funtions like starting the game using the spacebar,
//                     as well as quitting and restarting using esc, 'r', and enter respectively.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    #region Variables
    [Header("Variables related to the input options")]
    [SerializeField] private PlayerInput MyPlayerInput;
    private InputAction restartRound;
    private InputAction restartGame;
    private InputAction quit;
    private InputAction launch;

    [Header("Variables that determine whether keyboard input is taken")]
    [Tooltip("If the game is receiving input from players or not")]
    public bool ReceivingGameInputs;
    [Tooltip("If a player has reached 5 points yet or not")]
    public bool GameEnded;

    [Tooltip("References to game objects to disable them at beginning and end of game")]
    [SerializeField] private BallController ballController;
    [SerializeField] private GameObject startScene;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //disables balls or controllers from moving until player has exited start screen
        ReceivingGameInputs = false;
        GameEnded = false;

        PlayerInput();
    }

    /// <summary>
    /// Enables menu inputs like quit, restart round, restart game, and launch (which also starts game)
    /// </summary>
    #region Menu Functions
    private void PlayerInput()
    {
        MyPlayerInput.currentActionMap.Enable();

        quit = MyPlayerInput.currentActionMap.FindAction("Quit");
        restartRound = MyPlayerInput.currentActionMap.FindAction("RestartRound");
        restartGame = MyPlayerInput.currentActionMap.FindAction("RestartGame");
        launch = MyPlayerInput.currentActionMap.FindAction("Launch");

        quit.started += Quit_started;
        restartRound.started += RestartRound_started;
        restartGame.started += RestartGame_started;
        launch.performed += Launch_performed;
    }

    private void RestartRound_started(InputAction.CallbackContext obj)
    {
        //resets position of ball without modifying score when player preses 'r'
        ballController.ResetPosition();
    }

    private void RestartGame_started(InputAction.CallbackContext obj)
    {
        //reloads current scene when enter is pressed
        //essentially restarts game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Quit_started(InputAction.CallbackContext obj)
    {
        //quits game with escape key
        Debug.Log("Quit Game");
        Application.Quit();
    }

    private void Launch_performed(InputAction.CallbackContext obj)
    {
        //game has not started yet. pressing space the first time starts game
        if ((ReceivingGameInputs == false) && (GameEnded == false))
        {
            startScene.gameObject.SetActive(false);
            ReceivingGameInputs = true;
        }
        //game has ended. prevents player from launching ball and moving paddles
        else if((ReceivingGameInputs == false) && GameEnded == true)
        {
            ballController.ResetPosition();
        }
        else
        {
            //launches ball any other time space is pressed
            ballController.Launch();
        }
    }

    #endregion

    public void OnDestroy()
    {
        restartRound.started -= RestartRound_started;
        restartGame.started -= RestartGame_started;
        quit.started -= Quit_started;
        launch.performed -= Launch_performed;
    }
}
