/// <summary>
/// 
/// File: Player2Controller
/// Author: Isa Luluquisin
/// Date: November 7, 2023
/// 
/// Description: This controls Player 2's paddles (paddle to the right). 

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

    public InputController InputControllerInstance;
    #endregion

    private void Update()
    {
        GetInputFunctions();
    }

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
