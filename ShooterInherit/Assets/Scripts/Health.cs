using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100f; //private çünkü hataların önüne geçmek için yanlışlıkla değişmesini istemiyoruz, o yüzden serializedfield kullanıyoruz değiştirebilmek için.
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Vurduk");
            health -= 20;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
