/*****************************************************************************
// File Name : Player1Controller
// Author : Isa Luluquisin
// Creation Date : November 8, 2023
//
// Brief Description : This controls the player 1 paddle (paddle to the left)
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class Player1Controller : MonoBehaviour
{
    [Tooltip("References the paddle that it will be affecting")]
    [SerializeField] private Rigidbody2D paddle;
    [Tooltip("Determines the speed of the paddle")]
    [SerializeField] private float speed = 8;

    [Tooltip("References the input controller to check if recieving game inputs")]
    public InputController InputControllerInstance;

    private void Update()
    {
        GetInputFunctions();
    }

    /// <summary>
    /// Controls the player 1 paddle. Player 1 (paddle on left) may use W/S to move up and down.
    /// This can only be done if ReceivingGameInputs is true, as it being false indicates that 
    /// the game has not started yet.
    /// </summary>
    private void GetInputFunctions()
    {
        if(InputControllerInstance.ReceivingGameInputs)
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

        else
        {
            //prevents paddle movement if game is not receiving input
            paddle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
