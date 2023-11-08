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

public class BallController : MonoBehaviour
{
    #region Variables
    public bool wasLaunched; //change to private later
    private System.Random random;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
           GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 5f); //randomize this
            //GetComponent<Rigidbody2D>().velocity = new Vector2(random.NextFloat(10, 10), random.Next(10, 10));
        }
    }

    

    //method that speeds up ball's velocity
    //private void ballSpeed()

}
