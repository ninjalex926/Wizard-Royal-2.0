using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpellCastingBehaviour : MonoBehaviour {

	public int gunDamage = 1;											// Set the number of hitpoints that this gun will take away from shot objects with a health script
	public float fireRate = 0.25f;										// Number in seconds which controls how often the player can fire
	public float weaponRange = 50f;                                     // Distance in Unity units over which the player can fire
    public int manaCost;
    public int fireManaCost;
    public float hitForce = 100f;                                       // Amount of force which will be added to objects with a rigidbody shot by the player
    private int mana;
    public int fireMana;
	public Transform gunEnd;											// Holds a reference to the gun end object, marking the muzzle location of the gun

    public GameObject spellObject;

	private Camera fpsCam;												// Holds a reference to the first person camera
	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);	// WaitForSeconds object used by our ShotEffect coroutine, determines time laser line will remain visible
	private AudioSource gunAudio;										// Reference to the audio source which will play our shooting sound effect
	private LineRenderer laserLine;                                     // Reference to the LineRenderer component which will display our laserline
  
    public Image darkMask;

    public Text coolDownTextDisplay;

    private Image myButtonImage;


    public GameObject playerCharacter;

    public PlayerStats playerStats;

    public Mana_Bar manabar;

//    [HideInInspector]

    public float startingCoolDownTimer;

   public float nextFire;                                                // Float to store the time the player will be allowed to fire again, after firing


    public float currentCoolDownTime;

    public bool cooldownActive;

    //  public float coolDownDuration;

    void Start()
    {
        // Get and store a reference to our LineRenderer component
        laserLine = GetComponent<LineRenderer>();

        // Get and store a reference to our AudioSource component
        gunAudio = GetComponent<AudioSource>();

        // Get and store a reference to our Camera by searching this GameObject and its parents
        fpsCam = GetComponentInParent<Camera>();

        mana = playerCharacter.GetComponent<PlayerStats>().currentPlayerMana;


        fireMana = playerCharacter.GetComponent<PlayerStats>().currentFirePlayerMana;

        currentCoolDownTime = startingCoolDownTimer;

    }

    void Update () 
	{

        fireMana = playerCharacter.GetComponent<PlayerStats>().currentFirePlayerMana;

        // Check if the player has pressed the fire button and if enough time has elapsed since they last fired
        if (Input.GetButtonDown("Fire1") && !cooldownActive)
        {
            //  Does the Player Have Mana?
            if (mana > 0)
            {
                //  is the Spell Being Casted Fire Type
                if (spellObject.GetComponent<SpellStats>().elementType == "Fire")
                {
                    //  Does the player have fire mana?
                    if (fireMana > 0)
                    {
                        playerStats.FireManaCost(fireManaCost);

                        cooldownActive = true;

                        Mana_Bar mb = manabar.transform.GetComponent<Mana_Bar>();

                        playerStats.ManaCost(manaCost);

                        // Start our ShotEffect coroutine to turn our laser line on and off
                        StartCoroutine(ShotEffect());

                        // Create a vector at the center of our camera's viewport
                        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

                        // Declare a raycast hit to store information about what our raycast has hit
                        RaycastHit hit;

                        // Set the start position for our visual effect for our laser to the position of gunEnd
                        laserLine.SetPosition(0, gunEnd.position);

                        Instantiate(spellObject, gunEnd.position, transform.rotation);

                        // Check if our raycast has hit anything
                        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
                        {
                            // Set the end position for our laser line 
                            laserLine.SetPosition(1, hit.point);

                            // Check if the object we hit has a rigidbody attached
                            if (hit.rigidbody != null)
                            {
                                // Add force to the rigidbody we hit, in the direction from which it was hit
                                hit.rigidbody.AddForce(-hit.normal * hitForce);
                            }
                        }
                        else
                        {
                            // If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
                            laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
                        }
                    }
                    else
                    {
                        // You need fire mana to cast spell
                        print("OUT OF FIRE MANA");
                    }
                }
                //   The SPell Being casted is NOT FIRE 
                else
                {

                    cooldownActive = true;

                    Mana_Bar mb = manabar.transform.GetComponent<Mana_Bar>();

                    playerStats.ManaCost(manaCost);

                    // Start our ShotEffect coroutine to turn our laser line on and off
                    StartCoroutine(ShotEffect());

                    // Create a vector at the center of our camera's viewport
                    Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

                    // Declare a raycast hit to store information about what our raycast has hit
                    RaycastHit hit;

                    // Set the start position for our visual effect for our laser to the position of gunEnd
                    laserLine.SetPosition(0, gunEnd.position);

                    Instantiate(spellObject, gunEnd.position, transform.rotation);

                    // Check if our raycast has hit anything
                    if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
                    {
                        // Set the end position for our laser line 
                        laserLine.SetPosition(1, hit.point);

                        // Check if the object we hit has a rigidbody attached
                        if (hit.rigidbody != null)
                        {
                            // Add force to the rigidbody we hit, in the direction from which it was hit
                            hit.rigidbody.AddForce(-hit.normal * hitForce);
                        }
                    }
                    else
                    {
                        // If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
                        laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
                    }
                }
            }
            else if (mana <= 0)
            {
                print("No mana left");
            }
                mana = playerCharacter.GetComponent<PlayerStats>().currentPlayerMana;
            }
            else if (Input.GetButtonDown("Fire1") && Time.time < nextFire)
            {
                print("Wait until cooldown is done");
            }

            if (cooldownActive)
            {
                coolDownTextDisplay.text = Mathf.Round(currentCoolDownTime).ToString();

                // Timer count down
                currentCoolDownTime -= 1 * Time.deltaTime;

                darkMask.fillAmount = currentCoolDownTime / startingCoolDownTimer;

                // If timer has not 
                if (currentCoolDownTime > 0)
                {
                    // /loop
                }
                else
                // If timer had ended set the ring object array off
                {

                    cooldownActive = false;
                    currentCoolDownTime = startingCoolDownTimer;

                    // Update the time when our player can fire next
                    //     nextFire = Time.time + fireRate;
                }
            }       
    }

  
	private IEnumerator ShotEffect()
	{
		// Play the shooting sound effect
		gunAudio.Play ();

		// Turn on our line renderer
		laserLine.enabled = true;

		//Wait for .07 seconds
		yield return shotDuration;

		// Deactivate our line renderer after waiting
		laserLine.enabled = false;
	}
}