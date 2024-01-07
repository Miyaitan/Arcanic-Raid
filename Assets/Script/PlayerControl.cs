using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    //KeyCode Enter = Return
    private float Speed = 5;
    public Transform atkPoint;
    public Rigidbody2D bullet;
    public float timeBetweenShots = 1;
    private bool Shoot = true;

 

    private void Start()
    {

    }

    private void Update()
    {
        //PlayerStats player = gameObject.GetComponent<PlayerStats>();
        //player.stamina += 12 * Time.deltaTime;

        //if (player.stamina > 0)
        //{
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Movement();
            }
            else
            {
                Movement();
                Direction();
            }
        //}


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Shoot)
            {
                var spawnBullet = Instantiate(bullet, atkPoint.position, atkPoint.rotation);
                //player.stamina -= 8;
                StartCoroutine(DisallowShooting());
            }
        }
    }

    private void Movement()
    {
        //PlayerStats player = gameObject.GetComponent<PlayerStats>();
        Vector3 position = transform.position;
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            position.x -= Speed * Time.deltaTime * 0.7f;
            position.y += Speed * Time.deltaTime * 0.7f;
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            position.x -= Speed * Time.deltaTime * 0.7f;
            position.y -= Speed * Time.deltaTime * 0.7f;
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            position.x += Speed * Time.deltaTime * 0.7f;
            position.y += Speed * Time.deltaTime * 0.7f;
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            position.x += Speed * Time.deltaTime * 0.7f;
            position.y -= Speed * Time.deltaTime * 0.7f;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            position.x -= Speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            position.x += Speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            position.y += Speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            position.y -= Speed * Time.deltaTime;
        }
        transform.position = position;
        //player.stamina -= 10 * Time.deltaTime;
    }

    private void Direction()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 45f);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 0, 135f);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 315f);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 0, 225f);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 270f);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180f);
        }
    }
    private IEnumerator DisallowShooting()
    {
        Shoot = false;
        yield return new WaitForSeconds(timeBetweenShots);
        Shoot = true;
    }
}
