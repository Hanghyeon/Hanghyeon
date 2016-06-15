using UnityEngine;
using System.Collections;

public enum Player_State
{
    isalive,
    isdead
}

public abstract class Bird_Base : MonoBehaviour {

    #region public attributes

    public Player_State PS;
    public float Speed;
    public int Amount;
    public float Delay;
    public float Fall_Speed;
    public abstract Vector2 Position { get; set; }
    public abstract Vector2 Size { get; }
    
    #endregion

    #region non public attributes

    #endregion

    #region unity callbacks

    // Use this for initialization
    protected virtual void Awake () {
        PS = Player_State.isalive;
    }

    // Update is called once per frame
    protected virtual void Update () {
        
	}

    #endregion

    #region bird behaviour methods

    public abstract void Move(Vector2 move);
    public virtual void Move_Type2(Vector2 move)
    {
        //if(Input.get)
    }
    public abstract void ThrowPoo(int amount);

    #endregion


}
