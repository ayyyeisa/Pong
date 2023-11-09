/// <summary>
/// 
/// File: Player2Controller
/// Author: Isa Luluquisin
/// Date: November 7, 2023
/// 
/// Description: This controls Player 2's paddles (paddle to the right). 
/// Player 2 only has control over their own paddle. They will not be able
/// to start, restart, or quit the game.
/// 
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player2Controller : MonoBehaviour
{
    #region Variables

    [SerializeField] private float speed = 8;
    [SerializeField] private Rigidbody2D paddle;

    private float moveDirection;
    public bool ReceivingGameInputs;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //ReceivingGameInputs = false;
    }

    void Update()
    {
        GetInputFunctions();
    }

    private void GetInputFunctions()
    {
        //starts upward movement if player presses the up arrow
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            paddle.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1 * speed);
        }
        //ends upward movement if player stops pressing the up arrow key
        if (Input.GetKeyUp((KeyCode.UpArrow)))
        {
            paddle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        //starts downward movement if player presses the down arrow
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            paddle.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * speed);
        }
        //ends downward movement if player stops pressing the up arrow key
        if (Input.GetKeyUp((KeyCode.DownArrow)))
        {
            paddle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
