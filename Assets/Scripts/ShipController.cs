using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour
{

    float rotationSpeed = 100.0f;
    float thrustForce = 3f;

   

    public GameObject bullet;

    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject =
            GameObject.FindWithTag("GameController");

        gameController =
            gameControllerObject.GetComponent<GameController>();
    }

    void FixedUpdate()
    {

        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") *
            rotationSpeed * Time.deltaTime);

        GetComponent<Rigidbody2D>().
            AddForce(transform.up * thrustForce *
                Input.GetAxis("Vertical"));

        if (Input.GetMouseButtonDown(0))
            ShootBullet();

    }

    void OnTriggerEnter2D(Collider2D c)
    {

        if (c.gameObject.tag != "Bullet")
        {

           

            transform.position = new Vector3(0, 0, 0);

            GetComponent<Rigidbody2D>().
                velocity = new Vector3(0, 0, 0);

            gameController.DecrementLives();
        }
    }

    void ShootBullet()
    {

        Instantiate(bullet,
            new Vector3(transform.position.x, transform.position.y, 0),
            transform.rotation);

        
    }
}