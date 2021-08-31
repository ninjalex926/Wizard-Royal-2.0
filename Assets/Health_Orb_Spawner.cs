using UnityEngine;

public class Health_Orb_Spawner : MonoBehaviour
{
    //  The Gameobject that will spawn
    public GameObject HealthOrbRef;


    private float currentPosX = 684.84f;
    private float currentPosY = 180.91f;
    private float currentPosZ = 221.3f;



    private void OnTriggerEnter(Collider other)
    {
        //  Create a big explosion particle effect in the position
        //  of the current asteroid
        currentPosX = transform.position.x;

        currentPosY = transform.position.y;

        

        Vector3 Health_Orb_Pos = new Vector3(currentPosX, currentPosY, currentPosZ);

        Instantiate(HealthOrbRef, Health_Orb_Pos, Quaternion.identity);
    }
}

