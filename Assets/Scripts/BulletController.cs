using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{

    
    void Start()
    {
        Destroy(gameObject, 1.0f);

        GetComponent<Rigidbody2D>()
            .AddForce(transform.up * 400);
    }

}