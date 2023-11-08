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
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player1Controller : MonoBehaviour
{
    #region Variables
    [SerializeField] private PlayerInput MyPlayerInput;
    private InputAction restart;
    private InputAction quit;
    private InputAction launch;
    //private InputAction pause;

    //private bool isMoving;
    [SerializeField] private float speed = 4;
    [SerializeField] private Rigidbody2D paddle;

    private float moveDirection;
    public BallController BallController;
    public bool ReceivingGameInputs; //change to private later
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        PlayerInput();
    }

    void Update()
    {
        GetInputFunctions();
    }

    private void GetInputFunctions()
    {
        //starts upward movement if player presses w
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Player 1 is moving up");
            paddle.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1 * speed);
        }
        //ends upward movement if player stops pressing w
        if (Input.GetKeyUp((KeyCode.W)))
        {
            Debug.Log("Player 1 stopped moving up");
            paddle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        //starts downward movement if player presses the s
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Player 1 moves down");
            paddle.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * speed);
        }
        //ends downward movement if player stops pressing s
        if (Input.GetKeyUp((KeyCode.S)))
        {
            Debug.Log("Player 1 stopped moving down");
            paddle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    #region Menu Functions
    private void PlayerInput()
    {
        MyPlayerInput.currentActionMap.Enable();

        quit = MyPlayerInput.currentActionMap.FindAction("Quit");
        restart = MyPlayerInput.currentActionMap.FindAction("Restart");
        launch = MyPlayerInput.currentActionMap.FindAction("Launch");

        quit.started += Quit_started;
        restart.started += Restart_started;
        launch.performed += Launch_performed;
        //pause.started += Pause_started;
    }

    private void Restart_started(InputAction.CallbackContext obj)
    {
        //reloads current scene when r is pressed
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
        if (ReceivingGameInputs)
        {
            Debug.Log("Ball was launched");
            BallController.Launch();
        }
    }

    //private void Pause_started(InputAction.CallbackContext obj)
    //{
        //brings up pause menu
    //}
    #endregion

    public void OnDestroy()
    {
        restart.started -= Restart_started;
        quit.started -= Quit_started;
        launch.performed -= Launch_performed;
        //pause.started -= Pause_started;
        
    }
}
