/*****************************************************************************
// File Name : Player2Controller
// Author : Isa Luluquisin
// Creation Date : November 7, 2023
//
// Brief Description : This controls the player 2 paddle (paddle to the right)
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player2Controller : MonoBehaviour
{
    #region Variables

    [Tooltip("References the paddle that it will be affecting")]
    [SerializeField] private Rigidbody2D paddle;
    [Tooltip("Determines the speed of the paddle")]
    [SerializeField] private float speed = 8;

    [Tooltip("References the input controller to check if recieving game inputs")]
    public InputController InputControllerInstance;
    #endregion

    private void Update()
    {
        GetInputFunctions();
   }

    /// <summary>
    /// Controls the player 2 paddle. Player 2 (right paddle) may use up and down arrows 
    /// This can only be done if ReceivingGameInputs is true, as it being false indicates that 
    /// the game has not started yet.
    /// </summary>
    private void GetInputFunctions()
    {
        if(InputControllerInstance.ReceivingGameInputs)
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
        else
        {
            //prevents paddle movement if game is not receiving input
            paddle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
