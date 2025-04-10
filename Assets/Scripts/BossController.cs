using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    private string fasesBoss = "stage1";
    [SerializeField] private float speed = 2f;
    private Rigidbody rb;
    private bool direita = true;
    [SerializeField] private float limiteH = 14f;

    [SerializeField] private int vida = 1;
    public GameObject[] myGuns;
    private float nextFire;

    public float FireRate = 0.5f;
    private float CooldownTiro = 1f;
    [SerializeField] Transform myActiveGun;
    [SerializeField] private float velocidadeTiro = 10f;
    [SerializeField] private GameObject TiroInimigo;
    [SerializeField] private GameObject TiroSeguir;
    [SerializeField] private Transform posicaoTiro3;
    private float delayTiro = 1f;
    [SerializeField] private string[] stages;
    [SerializeField] private float stageTime = 10f;
    [SerializeField] private GameObject explosao;
    [SerializeField] string LevelChange;
    [SerializeField] private Image vidaimagem;
    [SerializeField] private int vidaTotal = 100;

 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myActiveGun = myGuns[0].transform;
        Scene currentScene = SceneManager.GetActiveScene();
        vida = vidaTotal;
    }

    void Update()
    {
        StageChange();

        switch (fasesBoss)
        {
            case "stage1":
                Stage1();
                break;
            case "stage2":
                Stage2();
                break;
            case "stage3":
                Stage3();
                break;
        }

        vidaimagem.fillAmount = ((float) vida /(float) vidaTotal);
        vidaimagem.color = new Color32(190, (byte) (vidaimagem.fillAmount * 255), 54, 255);
    }

    private void Stage1()
    {
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + 0.7f;
                for (int i = 0; i < myActiveGun.transform.childCount; i++)
                {
                    Instantiate(TiroInimigo, myActiveGun.GetChild(i).transform.position, myActiveGun.GetChild(i).transform.rotation);
                }
            }
        }

        if (direita)
        {    
            rb.linearVelocity = new Vector3(speed, 0f);
        }
        else
        {
            rb.linearVelocity = new Vector3(-speed, 0f);
        }

        if (transform.position.x >= limiteH)
        {
            direita = false;
        }
        else if (transform.position.x <= -limiteH)
        {
            direita = true;
        }
    }

    private void Stage2()
    {
        rb.linearVelocity = Vector2.zero;

        if (CooldownTiro <= 0f)
        {
            Tiro2();
            CooldownTiro = delayTiro / 2;
        }
        else
        {
            CooldownTiro -= Time.deltaTime;
        }
    }

    private void Stage3()
    {
        rb.linearVelocity = Vector2.zero;
        
        if (Time.time > nextFire)
        {
            nextFire = Time.time + 1f;
            for (int i = 0; i < myActiveGun.transform.childCount; i++)
            {
                Instantiate(TiroInimigo, myActiveGun.GetChild(i).transform.position, myActiveGun.GetChild(i).transform.rotation);
            }
        }


        if (CooldownTiro <= 0f)
        {
            Tiro2();
            CooldownTiro = delayTiro / 2;
        }
        else
        {
            CooldownTiro -= Time.deltaTime;
        }
    }

    private void Tiro2()
    {
        var Aviao = FindObjectOfType<Aviao>();

        if (Aviao)
        {
            Debug.Log("oi");
            var tiro = Instantiate(TiroSeguir, posicaoTiro3.transform.position, posicaoTiro3.transform.rotation);
            Vector2 direcao = Aviao.transform.position - tiro.transform.position;
            direcao.Normalize();
            tiro.GetComponent<Rigidbody>().linearVelocity = direcao * velocidadeTiro;
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
            tiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo - 90f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Tiro"))
        {
            PerdeVidaInimigo(25);
            Destroy(other.gameObject);
        }
    }

    public void PerdeVidaInimigo(int dano)
    {
        vida -= dano;

        if (vida <= 0)
        {
            Debug.Log("PerdeuPlaybas");
            SceneManager.LoadScene(2);
            Destroy(gameObject);
            
        }
        Debug.Log("PerdeuPlaybas");
    }

    private void StageChange()
    {
        if (stageTime <= 0f)
        {
            int indiceEstado = Random.Range(0, fasesBoss.Length);
            
            fasesBoss = stages[indiceEstado];

            stageTime = 10f;
        }
        else
        {
            stageTime -= Time.deltaTime;
        }
    }
}
