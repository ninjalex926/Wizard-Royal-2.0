
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage;

    public float range = 100f;

    public Camera fpsCam;

    private LineRenderer line;

    public GameObject hitEffect;

    public GameObject projectileObj;

    public Transform bulletSpawn;

    public float projectileForce = 100;

    private Transform hitTrans;

 public Rigidbody projectile;

    // Update is called once per frame
    void Update()
    {     
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hitInfo;
      if  (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.name);

            hitInfo.transform.GetComponent<Target>();

            Target target = hitInfo.transform.GetComponent<Target>();

            if( target != null)
            {
                target.TakeDamage(damage);
           
            }
       
       //    Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

          GameObject newPrjectile =  Instantiate(projectileObj, bulletSpawn.position, transform.rotation);

          //  newPrjectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, projectileForce, 0));

        //    Rigidbody clonedBullet = Instantiate(projectile, bulletSpawn.position, transform.rotation) as Rigidbody;

            //Add force to the instantiated bullet, pushing it forward away from the bulletSpawn location, using projectile force for how hard to push it away
           //    clonedBullet.AddForce(bulletSpawn.transform.forward * projectileForce);

            // newPrjectile.transform.AddForce(bulletSpawn.transform.forward * projectileForce);
        }
    }
}
