using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowGrass : MonoBehaviour
{
    private AudioSource audioSource;

    private TerrainDetector terrainDetector;

    public GameObject activeTerrian;

    public GameObject grass;

    public bool triggerByParticle;

    public bool triggerByCollision;



    private void Awake()
    {
        terrainDetector = new TerrainDetector();
    }
    public void Start()
    {
        activeTerrian = GameObject.Find("Terrain");
    }

    private void OnTriggerEnter(Collider other)
    {

            if (other.gameObject == activeTerrian)
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

    private void OnParticleCollision(GameObject other)
    {
      
            if (other.gameObject == activeTerrian)
            {
                int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

                switch (terrainTextureIndex)
                {
                    case 0:
                    Instantiate(grass, transform.position, transform.rotation);
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
