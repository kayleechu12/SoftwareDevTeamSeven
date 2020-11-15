using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSystem : MonoBehaviour
{
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsRemaining, bulletsUsed;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;


    public GameObject sprayEffect;
    
    private void playerInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsRemaining < magazineSize && !reloading) Reload();

        if (readyToShoot && shooting && !reloading && bulletsRemaining > 0)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);
        }
        Instantiate(sprayEffect, attackPoint.position, Quaternion.identity);

        bulletsUsed--;
        bulletsRemaining--;
        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsUsed > 0 && bulletsRemaining > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsRemaining = magazineSize;
        reloading = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        bulletsRemaining = magazineSize;
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerInput();
    }
}
