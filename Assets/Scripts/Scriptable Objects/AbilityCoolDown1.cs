using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityCoolDown1 : MonoBehaviour
{
    public Image darkMask;
    public Text coolDownTextDisplay;



    private Image myButtonImage;
    public GameObject player;

    public float currentCoolDownTime;



    void Start()
    {


    }



    // Update is called once per frame
    void Update()
    {
     
        if(currentCoolDownTime > 0)
        {
            currentCoolDownTime = -Time.deltaTime;
        }
        else if (currentCoolDownTime <= 0)
        {
            // Filled Can use ability
            
        }


    }

  
}