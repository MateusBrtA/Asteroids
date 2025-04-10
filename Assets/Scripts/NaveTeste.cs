using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveTeste : MonoBehaviour
{
    
    //Movimento
    [SerializeField] public float speed = 10;

    [SerializeField] public float xmin, xmax, ymin, ymax;

    public Rigidbody rigidbody;

    
    //Armas
    [SerializeField] Transform myActiveGun;

    [SerializeField] Transform Tiro;

    [SerializeField] float FireRate = 0.25f;

    public GameObject[] myGuns;

    private float nextFire;

    public GameCC controller;

    void FixedUpdate()
    {
        this.move();
        this.Atirar();
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        myActiveGun = myGuns[0].transform;
    }

    private void move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //movimento horizontal e vertical
        Vector3 moviment = new Vector3(moveHorizontal, moveVertical, 0.0f);

        //velocidade de movimento
        rigidbody.linearVelocity = moviment * speed;

       // rigidbody.position = new Vector3(
       //     Mathf.Clamp(rigidbody.position.x, bordas.xMin, bordas.xMax),
       //     Mathf.Clamp(rigidbody.position.y, bordas.yMin, bordas.yMax),
       //     0.0f);
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldmousepos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 dir = worldmousepos - transform.position;
        dir.z = 0;
        transform.up = dir;

        Teleporte();
    }

    private void Atirar()
    {
        if ((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && Time.time > nextFire)
        {
            nextFire = Time.time + FireRate;
            for (int i = 0; i < myActiveGun.transform.childCount; i++)
            {
                Instantiate(Tiro, myActiveGun.GetChild(i).transform.position, myActiveGun.GetChild(i).transform.rotation);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroide")
        {
            this.gameObject.SetActive(false);
            

            FindObjectOfType<GameCC>().PerderVida();
        }
        if (other.tag == "Atkspeed")
        {
           FireRate = FireRate * 0.5f;
           Invoke("VelocidaDeAtk", 4f);
           Destroy(other.gameObject);
        }
        if ((other.tag == "Slow"))
        {
            speed = 5;
            Invoke("VelocidadeMovimento", 3f);
            Destroy(other.gameObject);
        }
        if (other.tag == "tiroduplo")
        {
            myActiveGun = myGuns[1].transform;
            Invoke("ArmaAtiva", 4f);
            Destroy(other.gameObject);
        }
        if (other.tag == "TiroTriplo")
        {
            myActiveGun = myGuns[2].transform;
            Invoke("ArmaAtiva", 4f);
            Destroy(other.gameObject);
        }
        if (other.tag == "VelocidadeMov")
        {
            speed = 15;
            Invoke("VelocidadeMovimento", 4f);
            Destroy(other.gameObject);
        }
        if (other.tag == "TiroInimigo")
        {
            this.gameObject.SetActive(false);
            FindObjectOfType<GameCC>().PerderVida();
            Destroy(other.gameObject);
        }
    }

    public void VelocidaDeAtk()
    {
        FireRate = 0.25f;
    }

    public void ArmaAtiva()
    {
        myActiveGun = myGuns[0].transform;
    }

    public void VelocidadeMovimento()
    {
        speed = 10;
    }

   public void Teleporte()
   {
       if (transform.position.x < xmin)
       {
           transform.position = new Vector3(xmax, transform.position.y, transform.position.z);
       }
       else if (transform.position.x > xmax)
       {
           transform.position = new Vector3(xmin, transform.position.y, transform.position.z);
       }
   
       if (transform.position.y < ymin)
       {
           transform.position = new Vector3(transform.position.x, ymax, transform.position.z);
       }
       else if (transform.position.y > ymax)
       {
           transform.position = new Vector3(transform.position.x, ymin, transform.position.z);
       }
   }
}
