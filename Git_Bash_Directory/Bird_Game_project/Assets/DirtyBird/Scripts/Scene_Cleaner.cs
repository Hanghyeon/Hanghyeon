using UnityEngine;
using System.Collections;

public class Scene_Cleaner : MonoBehaviour
{

 


    #region check collision and triggers
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.gameObject.name);   
        DestroyObject(coll.gameObject);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        DestroyObject(other.gameObject);
    }
    #endregion
}
