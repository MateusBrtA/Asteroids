using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameCC : MonoBehaviour
{
    [SerializeField] NaveTeste nave;
    public int vidas = 3;
    public float reviver = 2.0f;
    public ParticleSystem explosao;
    public int pontos = 0;
    public Text vidasTxt;
    public Text pontosTxt;
    public static GameCC controller;
    public UIController uicontroller;
    [SerializeField] private GameObject bossAnimation;
    private bool animationBoss = false;

    void Awake()
    {
        controller = this;
    }

    private void Update()
    {
        if (pontos >= 4000)
        {
            GeraBoss();
        }
    }

    public void DestroiAsteroide(Asteroide asteroide)
    {
        this.explosao.transform.position = asteroide.transform.position;
        this.explosao.Play();

        if (asteroide.tamanho < 0.7f)
        {
            pontos += 100;
        }
        else if (asteroide.tamanho < 1.4f)
        {
            pontos += 50;
        }
        else 
        {
            pontos += 25;
        }
        pontosTxt.text = pontos.ToString();
    }
    public void PerderVida()
    {
        this.explosao.transform.position = this.nave.transform.position;
        this.explosao.Play();

        this.vidas--;
        vidasTxt.text = vidas.ToString();
        if (this.vidas <= 0)
        {
            Derrotado();
        }
        else
        {
        Invoke(nameof(Respawn), this.reviver);
        }
    }

    private void Respawn()
    {
        this.nave.transform.position = Vector3.zero;
        this.nave.gameObject.SetActive(true);
    }

    public void Derrotado()
    {
        this.vidas = 3;
        this.pontos = 0;
        uicontroller.Derrota();
    }

    public void Ganhador()
    {
        this.vidas = 3;
        this.pontos = 0;
        uicontroller.Ganhar();
    }

    private void GeraBoss()
    {
        if (!animationBoss)
        {
            GameObject animBoss = Instantiate(bossAnimation, new Vector3(0, 0, 0), transform.rotation);
            Destroy(animBoss, 7f);
            animationBoss = true;
        }
    }
}
