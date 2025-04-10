using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Slider GeralSlider, MusicSlider, VFXSlider;

    void Awake()
    {
        if (GeralSlider != null)
        {
            StartSound();
        }
    }

    private void StartSound()
    {
        AudioController.controller.mixer.GetFloat("VolGeral", out float aux);
        GeralSlider.value = aux;
        AudioController.controller.mixer.GetFloat("VolMusica", out float aux2);
        MusicSlider.value = aux2;
        AudioController.controller.mixer.GetFloat("VolVFX", out float aux3);
        VFXSlider.value = aux3;
    }

    public void TrocaMusicasCenas(string cena)
    {
        Time.timeScale = 1;
        AudioController.controller.MusicasCenas(cena);
        SceneManager.LoadScene(cena);
    }

    public void MudarVolGeral()
    {
        Debug.Log(GeralSlider.value);
        AudioController.controller.MudarVolGeral(GeralSlider.value);
    }
    public void MudarVolMusica()
    {
        Debug.Log(MusicSlider.value);
        AudioController.controller.MudarVolMusica(MusicSlider.value);
    }
    public void MudarVolVFX()
    {
        Debug.Log(VFXSlider.value);
        AudioController.controller.MudarVolVFX(VFXSlider.value);
    }
    

    private void Start()
    {
        GameCC.controller.uicontroller = this;
    }

    public GameCC controller;

    public void Inicio()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Ganhar()
    {
        SceneManager.LoadScene(2);
    }
    public void Derrota()
    {
        SceneManager.LoadScene(3);
    }
    public void Config()
    {
        SceneManager.LoadScene(4);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
