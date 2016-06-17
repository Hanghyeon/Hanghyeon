using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum GameState
{
    Play,
    Pause,
    End
}


public class GameManager : MonoBehaviour {

    #region public attributes
    public GameState GS;
    //public GUIText Text_Gold;
    public Text Text_Gold;

    public int Score = 0;
    #endregion

    #region non public attributes
    

    #endregion

    // Use this for initialization
    void Start () {
        GS = GameState.Play;
        GetCoin(Score);
    }
	
	// Update is called once per frame
	void Update () {

        if(GS==GameState.End)
        {
            Time.timeScale = 0;
        }
        else if(GS==GameState.Play)
        {
            Time.timeScale = 1;
        }
    }

    public void GetCoin(int _point)
    {
        Score += _point;
        Text_Gold.text = "Score : " + Score;
    }


}
