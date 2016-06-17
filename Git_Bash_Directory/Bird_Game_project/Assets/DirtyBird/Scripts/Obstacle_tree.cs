using UnityEngine;
using System.Collections;
using System;

public class Obstacle_tree : Obstacle_Base {


    #region Public attributes

    public override Vector2 Position
    {
        get
        {
            return _rigid2D.position;
        }

        set
        {
            _rigid2D.position = value;
        }
    }
    
    #endregion

    #region non Public attributes
    private Rigidbody2D _rigid2D;
    private BoxCollider2D _boxCollid2D;


    #endregion

    #region Unity CallBacks

    // Use this for initialization
    protected override void Awake()
    {
        _rigid2D = GetComponent<Rigidbody2D>();
        _boxCollid2D = GetComponent<BoxCollider2D>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        Move();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Poo")
        {

            Destroy(other.gameObject);
        }
        else if (other.transform.tag == "Player")
        {
            is_PlayerDead = true;
            other.gameObject.SetActive(false);
            GM.GS = GameState.End;
            //Destroy(other.gameObject);
        }
    }
    

    #endregion

    #region Obstacle Behaviour Methods
    public override void Move()
    {
        _rigid2D.velocity = Vector2.left * Speed;
    }

    


    #endregion
}
