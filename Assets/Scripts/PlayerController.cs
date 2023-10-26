using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region Variables
    public PlayerInput MyPlayerInput;
    private InputAction move;
    private InputAction restart;
    private InputAction quit;
    private InputAction launch;

    public float PaddleSpeed;
    private bool paddleIsMoving;
    public Rigidbody2D Paddle;
    private float moveDirection;
    public BallController BallController;
    public bool ReceivingGameInputs;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        MyPlayerInput.currentActionMap.Enable();
        move = MyPlayerInput.currentActionMap.FindAction("Move");
    }
}
