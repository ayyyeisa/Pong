/// <summary>
/// 
/// File: BallController
/// Author: Isa Luluquisin
/// Date: November 7, 2023
/// 
/// Description: This controls the ball's movement-- including launching.
/// 
/// </summary>
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
    [SerializeField] private Rigidbody2D ball;
    [SerializeField] private float speedMultiplier = 1.1f;
    private Vector2 randomVec;

    [SerializeField] private GameManager gM;
    public bool WasLaunched;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
    }
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
        //speeds up ball's velocity if it collides with paddles or walls
        else
        {   
            ball.velocity *= speedMultiplier;
        }
       
    }

    public void ResetPosition()
    {
        WasLaunched=false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.position = new Vector2(0, 0);
    }

    private Vector2 GenerateRandomVector()
    {
        randomVec = new Vector2(Random.Range(-6f, 6f), Random.Range(-6f, 6f));
        return randomVec;
    }

    public void Launch()
    {
        if(!WasLaunched)
        {
            WasLaunched = true;
            GetComponent<Rigidbody2D>().velocity = GenerateRandomVector();
        }
    }
}
