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

public class BallController : MonoBehaviour
{
    #region Variables
    [SerializeField] private Rigidbody2D ball;
    [SerializeField] bool wasLaunched;
    [SerializeField] private float ballSpeed = 3;
    private float ballSpeedMultiplier = .1f;
    private System.Random random;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!wasLaunched)
        {
            transform.position = new Vector2(0, 0);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Reached OnCollision");        
        if(collision.gameObject.tag == "KillBox")
        {
            Debug.Log("Ball reached Killbox");
            wasLaunched = false;
        }
        else
        {
            Debug.Log("Ball speed should be increasing");
            //ballSpeed *= ballSpeedMultiplier;
            ball.velocity = Vector2.Reflect(ball.velocity, collision.contacts[0].normal);
        }
       
    }

    //private static float NextFloat(float min, float max)
    //{
    //  random = new System.Random();
    //double val = (random.NextDouble() * (max - min) + min);
    //return (float)val;
    //}

    public void Launch()
    {
        if(!wasLaunched)
        {
            wasLaunched = true;
           GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 5f); //randomize this
            //GetComponent<Rigidbody2D>().velocity = new Vector2(random.NextFloat(10, 10), random.Next(10, 10));
        }
    }

    

    //method that speeds up ball's velocity
    //private void ballSpeed()

}
