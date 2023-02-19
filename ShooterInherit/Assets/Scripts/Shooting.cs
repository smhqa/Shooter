using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    public GameObject theBullet;
    public Transform barrelEnd;

    public int bulletSpeed;
    public float despawnTime = 3.0f;

    public bool shootAble = true;
    public float waitBeforeNextShot = 0.25f;

    public int curAmmo;
    public int fullAmmo = 30;
    public int backupAmmo;
    public float reloadTime = 3.0f;
    public float curReloadTime;
    public bool isReloading;

    public Text curAmmoText;
    public Text backupAmmoText;

    public int gunMode; // 1 - Full Auto 2 - Semi Auto 3 - Burst
    public int shotNum;
    public Text gunModeText;

    public void Start()
    {
        curAmmo = 30;
        backupAmmo = 90;
        gunMode = 1;
    }

    private void Update()
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

    void Shoot()
    {
        var bullet = Instantiate(theBullet, barrelEnd.position, barrelEnd.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        Destroy(bullet, despawnTime);
    }
}