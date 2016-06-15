using UnityEngine;
using System.Collections;

public enum Peaple_State:int
{
    Idle,
    Walk
}


public abstract class Peaple_Base : MonoBehaviour {

    #region Public attributes
    public float Speed;
    public bool is_alive = true;
    public int Point;
    public Peaple_State Statement;
    public abstract Vector2 Position { get; set; }
    public Player_State PS;

    #endregion

    #region non Public attributes


    #endregion

    #region Unity CallBacks

    protected virtual void Awake() { PS = GetComponent<Bird_Base>().PS; }

    // Use this for initialization
    //protected virtual void Start () {}

    // Update is called once per frame
    protected virtual void Update () {}

    protected virtual void OnTriggerEnter2D(Collider2D other) { }

    #endregion

    #region Peaple Behaviour Methods

    public abstract void HitPoo();
    public abstract void Idle();
    public abstract void Move();

    #endregion



}
