using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Quits the player when the user hits escape
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

   public void PressQuitGame()
    {
        Application.Quit();

    }

}





