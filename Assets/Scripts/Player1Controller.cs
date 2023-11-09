/// <summary>
/// 
/// File: Player1Controller
/// Author: Isa Luluquisin
/// Date: November 8, 2023
/// 
/// Description: This controls the player 1 paddle (paddle to the left)
/// 
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class Player1Controller : MonoBehaviour
{
    [SerializeField] private float speed = 8;
    [SerializeField] private Rigidbody2D paddle;

    public InputController InputControllerInstance;

    private void Update()
    {
        GetInputFunctions();
    }

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
