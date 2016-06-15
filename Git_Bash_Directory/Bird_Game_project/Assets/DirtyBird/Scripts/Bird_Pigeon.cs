using UnityEngine;
using System.Collections;
using System;

public class Bird_Pigeon : Bird_Base
{

    #region public attributes

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

    public override Vector2 Size
    {
        get
        {
            return _boxCollider2D.size; 
        }
    }

    public GameObject PooGO;

    #endregion

    #region non public attributes

    private Rigidbody2D _rigid2D;
    private BoxCollider2D _boxCollider2D;
    private Rigidbody2D _poo_rigid2D;


    #endregion

    #region unity callbacks

    // Use this for initialization
    protected override void Awake() 
    {
        //base.Awake();

        // MAKE MY OWN BEHAVIOUR
        Delay = 1.2f;

        // Get the reference of rigidbody2D on this game object
        _rigid2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        //_poo_rigid2D=GameObject.Find("Poo")

        

   	}
	
	// Update is called once per frame
	protected override void Update ()
    {

    }

    #endregion

    #region bird behaviour methods

    public override void Move(Vector2 direction)
    {
        _rigid2D.velocity = direction * Speed;
    }

    public override void ThrowPoo(int amount)
    {
        var birdPos = this.transform.position;                                         // Setting Poo position near the bird ass
        birdPos.x = this.transform.position.x - 4.36f;             // 
        birdPos.y = this.transform.position.y - 3.8f;             // 

        

        var poo = GameObject.Instantiate(PooGO, birdPos, PooGO.transform.rotation) as GameObject;
        var pooRidig2 = poo.GetComponent<Rigidbody2D>();
        var pooDir = new Vector2(-0.88f, -1f);
        var pooPow = Fall_Speed;

        pooRidig2.AddForce(pooDir * pooPow, ForceMode2D.Impulse);
        

    }

    #endregion

}
