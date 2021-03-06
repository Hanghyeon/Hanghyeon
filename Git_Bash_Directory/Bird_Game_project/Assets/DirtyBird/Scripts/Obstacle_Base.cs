﻿using UnityEngine;
using System.Collections;

public abstract class Obstacle_Base : MonoBehaviour {

    #region Public attributes
    public float Speed;
    public abstract Vector2 Position { get; set; }
    public bool is_PlayerDead = false;
    public GameManager GM;
    #endregion

    #region non Public attributes



    #endregion

    #region Unity CallBacks

    // Use this for initialization
    protected virtual void Awake()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {

    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {

    }



    #endregion

    #region Peaple Behaviour Methods

    public abstract void Move();


    #endregion

}
