using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class BordaMapa
{
    public float xMin, xMax, yMin, yMax;
    
}


public class Aviao : MonoBehaviour
{
    //inclinacao
    [SerializeField]
    private float slope = 4;
    //velocidade
    [SerializeField]
    public float speed = 10;
    //bordas
    [SerializeField]
    public BordaMapa bordas;

    public Rigidbody rigidbody;

    public GameObject vida1, vida2, vida3;
    int Vida = 3;

    public GameObject[] myGuns;

    [SerializeField] private GameObject explosao;
    public AudioSource explosaoSom;

    public bool isInvencible;
    public GameObject myShield;
    public int powerUpChance;
    float reverterbala = 0;

    [SerializeField]
    Transform myActiveGun;

    [SerializeField]
    Transform Tiro;

    [SerializeField]
    float FireRate = 0.25f;

    public AudioSource SomTiro;

    private float nextFire;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        myActiveGun=myGuns[0].transform;
    }

    private void Update()
    {
        print(Vida);

       
        
    }
    void FixedUpdate()
    {
        this.move();
        this.Atirar();
    }

    private void Atirar()
    {
        if ((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && Time.time > nextFire)
        {
            nextFire = Time.time + FireRate;
            for(int i=0;i<myActiveGun.transform.childCount;i++)
            {
            Instantiate(Tiro, myActiveGun.GetChild(i).transform.position, myActiveGun.GetChild(i).transform.rotation);
            }
        }
    }

    private void move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //movimento horizontal e vertical
        Vector3 moviment = new Vector3(moveHorizontal, moveVertical, 0.0f);

        //velocidade de movimento
        rigidbody.linearVelocity = moviment * speed;

        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, bordas.xMin, bordas.xMax),
            Mathf.Clamp(rigidbody.position.y, bordas.yMin, bordas.yMax),
            0.0f);
        //rotacionar a nave
        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.linearVelocity.x * -slope);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TiroInimigo")
        {
            PerderVida();
            Instantiate(explosao, transform.position, transform.rotation);
            explosaoSom.Play();
            Destroy(other.gameObject);
        }
        if (other.tag == "VidaPU")
        {
            AumentarVida();
            Destroy(other.gameObject);
        }
        if (other.tag == "tiroduplo")
        {
            myActiveGun=myGuns[1].transform;
            Destroy(other.gameObject);
        }
        if (other.tag == "Atkspeed")
        {
            FireRate = 0.10f;
            Destroy(other.gameObject);
        }
    }

    public void AumentarVida()
    {
        Vida++;
        if (Vida == 3)
        {
            vida3.SetActive(true);
            vida2.SetActive(true);
            vida1.SetActive(true);
        }
        else if (Vida == 2)
        {
            vida3.SetActive(false);
            vida2.SetActive(true);
            vida1.SetActive(true);
        }
    }

        public void PerderVida()
    {
        Vida--;
        if (Vida == 3)
        {

        }
        else if (Vida == 2)
        {
            vida3.SetActive(false);
        }
        else if (Vida == 1)
        {
            vida3.SetActive(false);
            vida2.SetActive(false);
        }
        else if (Vida == 0)
        {
            vida3.SetActive(false);
            vida2.SetActive(false);
            vida1.SetActive(false);
            Derrota();
        }
        
    }
    public void Derrota()
    {
        SceneManager.LoadScene(3);
    }




}
