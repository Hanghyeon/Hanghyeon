using UnityEngine;
using System.Collections;
using DG.Tweening;

public enum Bird_State
{
    fly,
    poo
}



public class Bird_movement : MonoBehaviour {

    public float Speed = 2f;
    public float Height = 2f;
    public float Jump_P = 10f;
    public Rigidbody rb;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
                                                                                                      //i want to dorp the bird always slow speed.
        //┌────────────────────────────────────────────────────────────────────┐                      //how to complete this work.
        //│             get input horizon, Vertical here                       │                     
        //└────────────────────────────────────────────────────────────────────┘                     
        //float Hori = Input.GetAxisRaw("Horizontal") * Time.deltaTime;                                  
        //float Verti = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        //Bird_fly_hori(Hori);
        Bird_fly_verti();
    }

    //┌────────────────────────────────────────────────────────────────────┐   
    //│             get input horizon fly left or Right side on the sky     │   
    //└────────────────────────────────────────────────────────────────────┘   

    void Bird_fly_hori(float Hori)
    {
        this.transform.Translate(new Vector3(Hori * Speed, 0.0f));
    }


    //┌────────────────────────────────────────────────────────────────────┐   
    //│             get input w. bird fly up the sky.                       │   
    //└────────────────────────────────────────────────────────────────────┘   

    void Bird_fly_verti()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.up * Jump_P);
        }
    }

    




}
