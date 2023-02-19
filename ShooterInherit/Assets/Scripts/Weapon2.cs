using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class Weapon2 : Weapons
{

    private void Start()
    {

    }

    public void Update()
    {
        curAmmoText.text = curAmmo.ToString();
        backupAmmoText.text = backupAmmo.ToString();
        gunModeText.text = gunMode.ToString();

        if (gunMode == 1)
        {
            gunModeText.text = "Full Auto";
            if (Input.GetKey(KeyCode.Mouse0) && !isReloading && curAmmo > 0)
            {
                if (shootAble)
                {
                    curAmmo--;
                    shootAble = false;
                    Shoot();
                    StartCoroutine(ShootingYield());
                }
            }
        }
        else if (gunMode == 2)
        {
            gunModeText.text = "Semi Auto";
            if (Input.GetKeyUp(KeyCode.Mouse0) && !isReloading && curAmmo > 0)
            {
                if (shootAble)
                {

                    curAmmo--;
                    shootAble = false;
                    Shoot();
                    StartCoroutine(ShootingYield());
                }
            }
        }
        else if (gunMode == 3)
        {
            gunModeText.text = "Burst";
            if (Input.GetKeyDown(KeyCode.Mouse0) && !isReloading && curAmmo > 0 && shotNum == 0)
            {

                BurstFire();
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && backupAmmo > 0)
        {
            curReloadTime = reloadTime;
            isReloading = true;
            Reload();
        }
        if (isReloading)
        {
            curReloadTime -= Time.fixedDeltaTime;

            if (curReloadTime <= 0)
            {
                isReloading = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (gunMode < 3)
            {
                gunMode++;
            }
            else if (gunMode == 3)
            {
                gunMode = 1;
            }
        }
        if (shotNum == 3)
        {
            shotNum = 0;
        }
    }


    void BurstFire()
    {
        if (shotNum < 3)
        {
            if (curAmmo > 0)
            {
                curAmmo--;
                Shoot();
                StartCoroutine(ShootingYield());
            }
        }
    }

    void Reload()
    {
        var shot = fullAmmo - curAmmo;
        shotNum = 0;

        if (backupAmmo < shot)
        {
            curAmmo += backupAmmo;
            backupAmmo = 0;
        }
        else
        {
            curAmmo += shot;
            backupAmmo -= shot;
        }
    }

    IEnumerator ShootingYield()
    {
        yield return new WaitForSeconds(waitBeforeNextShot);

        if (gunMode != 3)
        {
            shootAble = true;
        }

        if (gunMode == 3)
        {
            shotNum++;
            BurstFire();
        }
    }
    public void sekme(int a, int b)
    {
        var bullet = Instantiate(theBullet, barrelEnd.position, barrelEnd.rotation);
        bullet.transform.Rotate(new Vector3(UnityEngine.Random.Range(a, b), UnityEngine.Random.Range(a, b), 0));
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * rateOfFireBulletSpeed;
        Destroy(bullet, despawnTime);
    }
    void Shoot()
    {
        var bullet = Instantiate(theBullet, barrelEnd.position, barrelEnd.rotation);
        //var bullet = Instantiate(theBullet, barrelEnd.position, Quaternion.Euler(0, 90, 0));

        if (Accurate == 10)
        {

            sekme(0, 1);


        }
        else if (Accurate >= 8)
        {


            bullet.transform.Rotate(new Vector3(UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(-1, 1), 0));
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * rateOfFireBulletSpeed;
            Destroy(bullet, despawnTime);


        }
        else if (Accurate >= 7)
        {
            bullet.transform.Rotate(new Vector3(UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(-2, 2), 0));
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * rateOfFireBulletSpeed;
            Destroy(bullet, despawnTime);

        }
        else if (Accurate < 4 && Accurate > 1)
        {
            bullet.transform.Rotate(new Vector3(UnityEngine.Random.Range(-4, 4), UnityEngine.Random.Range(-4, 4), 0));
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * rateOfFireBulletSpeed;
            Destroy(bullet, despawnTime);
        }


        //var bullet = Instantiate(theBullet, barrelEnd.position, barrelEnd.rotation);
        //bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * rateOfFireBulletSpeed;
        //Destroy(bullet, despawnTime);

    }

}
