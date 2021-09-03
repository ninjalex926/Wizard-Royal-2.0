using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookOnOff : MonoBehaviour
{

    public bool isActive;

    public GameObject spellBook;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {

            if(isActive)
            {
                spellBook.SetActive(false);
                isActive = false;
            }
            else
            {
                spellBook.SetActive(true);
                isActive = true;
            }

        }
    }
}
