using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapons : MonoBehaviour
{
    public string Name;
    public float Accurate;
    public int rateOfFireBulletSpeed;
    public float despawnTime;
    public float waitBeforeNextShot;
    public int curAmmo;
    public int fullAmmo;
    public int backupAmmo;
    public float reloadTime;
    public float curReloadTime;
    public int gunMode; // 1 - Full Auto 2 - Semi Auto 3 - Burst
    public int shotNum;
    public GameObject theBullet;
    public Transform barrelEnd;
    public bool shootAble = true;
    public bool isReloading;
    public Text curAmmoText;
    public Text backupAmmoText;
    public Text gunModeText;


    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }
}
