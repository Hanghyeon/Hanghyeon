using UnityEngine;
using System.Collections;

public class Lock_in_view : MonoBehaviour {

    public Transform Object;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        obj_locked_in_view(Object);

    }

    void obj_locked_in_view(Transform obj)
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(obj.position);

        if (pos.x < 0f)
        {
            pos.x = 0f;
        }

        if (pos.x > 1f)
        {
            pos.x = 1f;
        }

        if (pos.y < 0f)
        {
            pos.y = 0f;
        }

        if (pos.y > 1f)
        {
            pos.y = 1f;
        }

        obj.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
