using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public Transform CannonObject;
    public Collider MouseRayCastTarget;
    public Transform FirePoint;
    public GameObject CannonBallPrefab;
    public GameObject BigCannonBallPrefab;
    public GameObject BarrelPuffPrefab;

    [System.NonSerialized]
    int AmmoMax = 10;
    public int Ammo = 10;
    float AmmoCooldown = 1;
    float AmmoTimer = 1;
    float fireCooldown = 0;

    public float infiniteAmmoTime = 0;
    public float bigBulletTime = 0;
    public float spreadshotTime = 0;

	// Update is called once per frame
	void Update () {
        if(GameManager.isPaused)
            return;

        if(GetComponent<Health>() != null && GetComponent<Health>().isDead == true)
        {
            return;
        }

        if(Ammo < AmmoMax)
            AmmoTimer -= Time.deltaTime;

        if(AmmoTimer <= 0 && Ammo < AmmoMax)
        {
            AmmoTimer = AmmoCooldown;
            Ammo ++;
        }

        infiniteAmmoTime -= Time.deltaTime;
        bigBulletTime -= Time.deltaTime;
        spreadshotTime -= Time.deltaTime;
        fireCooldown -= Time.deltaTime;
		
        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        RaycastHit hitInfo;

        if( MouseRayCastTarget.Raycast(ray, out hitInfo, Mathf.Infinity) )
        {
            Vector3 mouseTarget = hitInfo.point;

            Vector3 lookVector = CannonObject.position - mouseTarget;
            lookVector.y = 0;

            CannonObject.rotation = Quaternion.LookRotation(lookVector);

            if(fireCooldown <= 0)
            {
                if( infiniteAmmoTime > 0 || (Ammo > 0 && Input.GetButtonDown("Fire1")) )
                {
                    if(infiniteAmmoTime <= 0)
                        Ammo--;

                    fireCooldown = 0.1f;

                    GameObject prefab = CannonBallPrefab;
                    if(bigBulletTime > 0)
                        prefab = BigCannonBallPrefab;

                    CannonObject.GetComponent<AudioSource>().Play();

                    GameObject go = (GameObject)Instantiate(prefab, FirePoint.position, Quaternion.identity);
                    go.GetComponent<CannonBall>().ParentObject = this.transform.root;
                    go.GetComponent<CannonBall>().destination = mouseTarget;

                    if(spreadshotTime > 0)
                    {

                        Vector3 angledTarget = 
                            CannonObject.position +
                            (Quaternion.Euler(0, CannonObject.rotation.eulerAngles.y - 10, 0) * Vector3.back * 1000);
                        
                        go = (GameObject)Instantiate(prefab, FirePoint.position, Quaternion.identity);
                        go.GetComponent<CannonBall>().ParentObject = this.transform.root;
                        go.GetComponent<CannonBall>().destination = angledTarget;

                        angledTarget = 
                            CannonObject.position +
                            (Quaternion.Euler(0, CannonObject.rotation.eulerAngles.y + 10, 0) * Vector3.back * 1000);
                        
                        go = (GameObject)Instantiate(prefab, FirePoint.position, Quaternion.identity);
                        go.GetComponent<CannonBall>().ParentObject = this.transform.root;
                        go.GetComponent<CannonBall>().destination = angledTarget;
                    }

                    Instantiate(BarrelPuffPrefab, FirePoint.position, FirePoint.rotation);

                }
            }
            
        }


	}
}
