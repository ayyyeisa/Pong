/// <summary>
/// 
/// File: InputController
/// Author: Isa Luluquisin
/// Date: October something, 2023
/// 
/// Description: This controls funtions like starting the game using the spacebar,
/// as well as quitting and restarting using esc, 'r', and enter respectively.
/// 
/// </summary>
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
    [SerializeField] private PlayerInput MyPlayerInput;
    private InputAction restartRound;
    private InputAction restartGame;
    private InputAction quit;
    private InputAction launch;

    public bool ReceivingGameInputs;
    public bool GameEnded;
    [SerializeField] private BallController ballController;
    [SerializeField] private GameObject startScene;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ReceivingGameInputs = false;
        GameEnded = false;
        PlayerInput();
    }

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
        ballController.ResetPosition();
    }

    private void RestartGame_started(InputAction.CallbackContext obj)
    {
        //reloads current scene when enter is pressed
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
        //game has not started yet or game has ended
        if ((ReceivingGameInputs == false) && (GameEnded == false))
        {
            startScene.gameObject.SetActive(false);
            ReceivingGameInputs = true;
        }
        else if((ReceivingGameInputs == false) && GameEnded == true)
        {
            ballController.ResetPosition();
        }
        else
        {
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
