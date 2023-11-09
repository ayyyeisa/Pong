/*****************************************************************************
// File Name : BallController.cs
// Author : Isa Luluquisin
// Creation Date : November 7, 2023
//
// Brief Description : This controls the ball's movement, which includes 
///                    launching, velocity, and positions throughout game.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;
using Random = UnityEngine.Random;
using Unity.VisualScripting;
using TMPro;

public class BallController : MonoBehaviour
{
    #region Variables
    [Tooltip("References the ball sprite")]
    [SerializeField] private Rigidbody2D ball;
    [Tooltip("References game manager script")]
    [SerializeField] private GameManager gM;

    //how much a ball speeds up after collisions
    private float speedMultiplier = 1.1f;
    //random vec for ball's launch direction
    private Vector2 randomVec;
    //x and y components of the random vector
    private float randomVecX;
    private float randomVecY;

    public bool WasLaunched;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //limits ball's velocity to a magnitude of 12
        if(ball.velocity.magnitude >= 12)
        {
            ball.velocity = Vector2.ClampMagnitude(ball.velocity, 12f);
        }
    }

    /// <summary>
    /// This method handles what happens after the ball collides with specific objects. 
    /// It will check if objects are killboxes, which if so, causes the score to be updated 
    /// and for the ball's reposition back to the center. If objects are the walls or 
    /// paddles, ball's velocity will speed up.
    /// </summary>
    /// <param name="collision">The collision of the ball and other game object</param>
    public void OnCollisionEnter2D(Collision2D collision)
    {     
        if(collision.gameObject.tag == "P1KillBox")
        {
            gM.UpdateP2Score();
            ResetPosition();
        }
        else if(collision.gameObject.tag == "P2KillBox")
        {
            gM.UpdateP1Score();
            ResetPosition();
        }
        //speeds up ball's velocity by 10% if it collides with paddles or walls
        else
        {   
            ball.velocity *= speedMultiplier; //speed multiplier is 1.1
        }
       
    }

    public void ResetPosition()
    {
        WasLaunched=false;
        ball.velocity = Vector2.zero;
        transform.position = new Vector2(0, 0);
    }

    private Vector2 GenerateRandomVector()
    {
        randomVecX = GenerateRandomVelocity();
        randomVecY = GenerateRandomVelocity();
        randomVec = new Vector2(randomVecX, randomVecY);
        return randomVec;
    }

    private float GenerateRandomVelocity()
    {
        float num = Random.Range(0, 5);
        float sign = Random.Range(0, 2);

        //generates a number for the velocity
        #region if statements for number
        if (num == 0)
        {
            num = Random.Range(5f, 6f);
        }
        else if(num == 1)
        {
            num = Random.Range(6f, 7f);
        }
        else if (num == 2)
        {
            num = Random.Range(7f, 8f);
        }
        else if (num == 3)
        {
            num = Random.Range(8f, 9f);
        }
        else if (num == 4)
        {
            num = Random.Range(9f, 10f);
        }
        #endregion

        //determines whether velocity is positive or negative
        #region if statements for sign
        //sign = 0 indicates a positive velocity
        if (sign == 0)
        {
            num *= 1;
        }
        //sign = 1 indicates a negative velocity
        if (sign == 1)
        {
            num *= -1;
        }
        #endregion
        return num;
    }

    public void Launch()
    {
        if(!WasLaunched)
        {
            WasLaunched = true;
            ball.velocity = GenerateRandomVector();
        }
    }
}
