using UnityEngine;
using System.Collections;
using DG.Tweening;


public class Scroll_Background : MonoBehaviour {

    public float Scroll_Speed = 0.5f;
    private float Offset;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Offset += Time.deltaTime * Scroll_Speed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Offset, 0);
	}
}
