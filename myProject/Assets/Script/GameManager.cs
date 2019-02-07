using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Instance
    {
        set;
        get;
    }
	// Use this for initialization
	private void Start ()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

         
	}

    public void NewGameButton()
    {
        Debug.Log("New Game");
    }
    
    public void ExitGameButton()
    {
        Debug.Log("Exit Game");
    }

	// Update is called once per frame
	void Update () {
	
	}
}
