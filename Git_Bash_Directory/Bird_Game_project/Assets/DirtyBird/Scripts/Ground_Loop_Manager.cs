using UnityEngine;
using System.Collections;

public class Ground_Loop_Manager : MonoBehaviour {

    #region public attributes
    public float Speed = 0.1f;
    public GameObject Ground_Now;
    public GameObject Ground_Second;
    public GameObject[] Grounds;
    #endregion

    #region non public attributes
    private Transform Save_Sec_Pos;
    private Transform Save_Thi_Pos;
    #endregion

    #region Unity Callbacks
    void Update()
    {
        Move();

    }
    #endregion



    #region Methods
    void Move()
    {
        Ground_Now.transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.Self);
        Ground_Second.transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.Self);
        

        if(Ground_Now.transform.position.x<= -167f)
        {
            DestroyGround();
        }
    }

    void Make()
    {

        var SecondPos = Ground_Second.transform;
        Ground_Now = Ground_Second;
        int type = Random.Range(0, Grounds.Length);
        Ground_Second =Instantiate(Grounds[type], new Vector2(189f, 2.6f), Quaternion.identity) as GameObject;
        Ground_Second.transform.parent = transform;
    }

    void DestroyGround()
    {
        Destroy(Ground_Now);
        Make();
    }
    #endregion
}
