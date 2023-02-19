using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowMaterial : MonoBehaviour
{
    public GameObject throwMaterial;
    public Transform throwMatEnd;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //var throwMat = Instantiate(throwMaterial, throwMatEnd.position, throwMatEnd.rotation);
        //throwMat.GetComponent<Rigidbody>().velocity = throwMat.transform.forward * 10f;
        //Destroy(throwMat, 1f);
    }
}
