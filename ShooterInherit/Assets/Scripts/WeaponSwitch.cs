using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    // Start is called before the first frame update
    void Start()
    {
        weapon1.SetActive(true);
        weapon2.SetActive(false);
        weapon3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            weapon1.SetActive(true);
            weapon2.SetActive(false);
            weapon3.SetActive(false);
        }
        if (Input.GetKey("2"))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true);
            weapon3.SetActive(false);
        }
        if (Input.GetKey("3"))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(false);
            weapon3.SetActive(true);
        }
    }
}
