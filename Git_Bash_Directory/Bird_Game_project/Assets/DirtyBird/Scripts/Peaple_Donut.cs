using UnityEngine;
using System.Collections;

public class Peaple_Donut : Peaple_Base
{

    #region Public Attributes

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


    #region Non Public Attributes

    private BoxCollider2D _boxColli2D;
    private Rigidbody2D _rigid2D;
    

    #endregion

    #region Unity CallBacks

    protected override void Awake ()
    {
        var minRan = 0;
        var maxRan = 2;

        int randomInt = Random.Range(minRan, maxRan);

        if(randomInt==0)
        {
            Debug.Log("Idle");
            base.Statement = Peaple_State.Idle;
        }
        else
        {
            Debug.Log("Walk");
            base.Statement = Peaple_State.Walk;
        }

        _boxColli2D = GetComponent<BoxCollider2D>();
        _rigid2D = GetComponent<Rigidbody2D>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

        Point = 2;
    }

 //   // Use this for initialization
 //   protected override void Start ()
 //   {
 //       Point = 2;
	//}
	
	// Update is called once per frame
	protected override void Update ()
    {
        if(base.Statement == Peaple_State.Walk)
        {
            Move();
        }
        else
        {
            Idle();
        }
        
	}

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Poo") && is_alive)
        {
            HitPoo();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Player") && is_alive)
        {
            
            is_PlayerDead = true;
            other.gameObject.SetActive(false);
            GM.GS = GameState.End;
            //Destroy(other.gameObject);
        }
        
        
    }

    #endregion


    #region bird behaviour methods

    public override void HitPoo()
    {
        is_alive = false;
        var jump = 10f;                                                         // ─┐
        var torque = 700f;                                                      //  │
                                                                                //  │
        _rigid2D.transform.Translate(Vector2.up * jump);                        //  │
        _rigid2D.AddTorque(torque*1f,ForceMode2D.Force);                        //  ├나중에 애니메이션으로 대체될 곳
        _rigid2D.gravityScale = 100f;                                           //  │
        _rigid2D.mass = 1f;                                                     // ─┘

        Debug.Log("What? oh..MY..");
        GM.GetCoin(Point);
    }

    public override void Idle()
    {
        Speed = 0f;
        _rigid2D.velocity = Vector2.left * Speed;
    }

    public override void Move()
    {
        Speed = 8f;
        _rigid2D.velocity = Vector2.left * Speed;
    }
    



    #endregion


}
