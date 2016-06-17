using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Bird_Controller : MonoBehaviour
{

    #region public attributes

    public static Bird_Controller Singleton;
    public GameManager GM;
    #endregion

    #region non public attributes

    private Bird_Base _bird;
    private System.Action<Vector2> _OnDidInput;
    
    #endregion

    #region unity callbacks

    void Awake()
    {
        Singleton = this;

        var allBirds = GameObject.FindObjectsOfType<Bird_Base>();
        _bird = allBirds[0];

        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Use this for initialization
    void Start ()
    {
        
        _OnDidInput += Movement;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(GetInputAction())
            CheckBoundaries();
    }

    #endregion

    #region public methods
   
    public void CheckBoundaries()
    {
        Vector2 new_bird_pos = _bird.Position;

        float height = 100f;                                                             //Display size: 960x540
        float width = ((Screen.width / (float)Screen.height) * 100f) / 2f;                //    but view size is (0,0)~(1,1)
                                                                                        //    so we changed size on world
        if (new_bird_pos.x - _bird.Size.x / 2 < -width)                                 //
            new_bird_pos.x = -width + _bird.Size.x / 2;                                 // (0,1)┌────────┐(1,1)  ┐
                                                                                        //      │        │       height=100f
        if (new_bird_pos.x + _bird.Size.x / 2 > width)                                  // (0,0)└────────┘(1,0)  ┘
            new_bird_pos.x = width - _bird.Size.x / 2;                                  //       └─┬─┴─┬─┘
                                                                                        //  -width ┘   └ +width
        if (new_bird_pos.y - _bird.Size.y / 2 < 0f)                                     //        width=50f ->중단점찍고 디버그 하니깐 88.8888888~f나옴
            new_bird_pos.y = 0f + _bird.Size.y / 2;                                     //

        if (new_bird_pos.y + _bird.Size.y / 2 > height)
            new_bird_pos.y = height - _bird.Size.y / 2;

        _bird.Position = new_bird_pos;
    }

    #endregion

    #region non public methods

    bool GetInputAction()
    {
        if (Input.anyKey&&GM.GS==GameState.Play)
        {
            float y = Input.GetAxisRaw("Vertical");
            float x = Input.GetAxisRaw("Horizontal");

            _OnDidInput(new Vector2(x, y));

            bool is_throw = Input.GetKeyDown(KeyCode.Mouse0);

            ThrowPoo(is_throw);

            return true;
        }

        _OnDidInput(new Vector2(0, 0));

        return false;
    }

    void Movement(Vector2 direction)
    {
        _bird.Move(direction);
    }

    void ThrowPoo(bool isPushThrowKey)
    {
        if(isPushThrowKey)
            _bird.ThrowPoo(_bird.Amount);
               
    }



    #endregion

    //void OnTriggerEnter2D(Collision2D obj)
    //{

    //}


}
