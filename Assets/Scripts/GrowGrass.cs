using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowGrass : MonoBehaviour
{
    private AudioSource audioSource;

    private TerrainDetector terrainDetector;

    public GameObject activeTerrian;

    public GameObject grassSpawnPoint;

    public GameObject grass;

 //   public bool triggerByParticle;

   // public bool triggerByCollision;

 //   public bool spawnable;
    private Vector3 tPosition;

    public Quaternion AutoSetRotation { get; private set; }

    private Vector3 myVector;

    private void Awake()
    {
        terrainDetector = new TerrainDetector();
    }

    public void Start()
    {
        activeTerrian = GameObject.Find("Terrain");
        terrainDetector = new TerrainDetector();
    }


    /// <summary>
    /// Checks if is TRIGGER ENTER 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grass")
        {

        }
        else if (other.gameObject == activeTerrian)
        {
         //   spawnable = true;
            int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

            if (tPosition != grassSpawnPoint.transform.position)
            {
                switch (terrainTextureIndex)
                {
                    case 0:
                        print("TOUCHING NOTHING");
                        break;
                    case 1:
                        print("TOUCHING gras");
                        Instantiate(grass, grassSpawnPoint.transform.position, grassSpawnPoint.transform.rotation);

                        tPosition = grassSpawnPoint.transform.position;
                        AutoSetRotation = grassSpawnPoint.transform.rotation;
                        print("TOUCHING Grass");
                        break;
                    default:
                        print("TOUCHING NOTHING");
                        break;
                }
            }
        }
    }


    /// <summary>
    /// CHecks to see if using SOLID PARTILCE Colliosn
    /// </summary>
    /// <param name="other"></param>
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Grass")
        {

        }
        else if (other.gameObject == activeTerrian)
        {
       //     spawnable = true;

         
            int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);


            if(tPosition != grassSpawnPoint.transform.position)
            {
                switch (terrainTextureIndex)
                {
                    case 0:
                        Instantiate(grass, grassSpawnPoint.transform.position, grassSpawnPoint.transform.rotation);
                        tPosition = grassSpawnPoint.transform.position;
                        AutoSetRotation = grassSpawnPoint.transform.rotation;
                        print("TOUCHING Grass");
                        break;
                    case 1:
                        print("TOUCHING Dirt");
                        break;
                    default:
                        print("TOUCHING NOTHING");
                        break;
                }
            }    
        }    
    }




    /// <summary>
    /// Checks to see if SOILID Collsion is taking place
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == activeTerrian)
        {
            int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

            switch (terrainTextureIndex)
            {
                case 0:
                    print("TOUCHING GRASS");
                    break;
                case 1:
                    print("TOUCHING Dirt");
                    break;
                default:
                    print("TOUCHING NOTHING");
                    break;
            }
        }
    }
}
