/// <summary>
/// 
/// File: Player1Controller
/// Author: Isa Luluquisin
/// Date: October something, 2023
/// 
/// Description: This controls Player 1's paddles (paddle to the left). 
/// Player 1 is capable of starting the game using the spacebar,
/// as well as quitting and restarting using esc and 'r' respectively.
/// 
/// </summary>
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player1Controller : MonoBehaviour
{
    #region Variables
    [SerializeField] private PlayerInput MyPlayerInput;
    private InputAction restartRound;
    private InputAction restartGame;
    private InputAction quit;
    private InputAction launch;
    //private InputAction pause;

    private float speed = 8;
    [SerializeField] private Rigidbody2D paddle;

    private float moveDirection;
    [SerializeField] private BallController ballController;
    [SerializeField] private bool ReceivingGameInputs;
    [SerializeField] private TMP_Text startText;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ReceivingGameInputs = false;
        PlayerInput();
    }

    void Update()
    {
        GetInputFunctions();
    }

    private void GetInputFunctions()
    {
        if(ReceivingGameInputs)
        {
            //starts upward movement if player presses w
            if (Input.GetKeyDown(KeyCode.W))
            {
                paddle.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1 * speed);
            }
            //ends upward movement if player stops pressing w
            if (Input.GetKeyUp((KeyCode.W)))
            {
                paddle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

            //starts downward movement if player presses the s
            if (Input.GetKeyDown(KeyCode.S))
            {
                paddle.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * speed);
            }
            //ends downward movement if player stops pressing s
            if (Input.GetKeyUp((KeyCode.S)))
            {
                paddle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
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
        launch.performed += Launch_performed;
        //pause.started += Pause_started;
    }

    private void RestartRound_started(InputAction.CallbackContext obj)
    {
        ballController.RestartRound();
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
        //receiving game inputs = start scene has already been disabled
        if (ReceivingGameInputs)
        {
            ballController.Launch();
        }
        //game has not started yet
        else
        {
            startText.gameObject.SetActive(false);
            ReceivingGameInputs = true;
        }
    }

    //private void Pause_started(InputAction.CallbackContext obj)
    //{
        //brings up pause menu
    //}
    #endregion

    public void OnDestroy()
    {
        restartRound.started -= RestartRound_started;
        restartGame.started -= RestartGame_started;
        quit.started -= Quit_started;
        launch.performed -= Launch_performed;
        //pause.started -= Pause_started;
        
    }
}
