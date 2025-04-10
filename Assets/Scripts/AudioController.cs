using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public static AudioController controller;
    public AudioSource audioSource;
    public AudioClip[] musicas;
    public AudioMixer mixer;

    void Awake()
    {
        if (controller == null)
        {
            controller = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void MusicasCenas(string cena)
    {
        switch (cena)
        {
            case "Inicio":
                audioSource.clip = musicas[0];
                break;
            case "Jogo":
                audioSource.clip = musicas[1];
                break;
            default:
                break;
        }
        audioSource.Play();
    }

    public void MudarVolGeral(float valor)
    {
        if (valor <= -19)
        {
            mixer.SetFloat("VolGeral", -80f);
        }
        else
        {
            mixer.SetFloat("VolGeral", valor);
        }
    }
    public void MudarVolVFX(float valor)
    {
       if (valor <= -19)
       {
           mixer.SetFloat("VolVFX", -80f);
       }
       else
        {
            mixer.SetFloat("VolVFX", valor);
        }
    }
    public void MudarVolMusica(float valor)
    {
       if (valor <= -19)
       {
           mixer.SetFloat("VolMusica", -80f);
       }
       else
        {
            mixer.SetFloat("VolMusica", valor);
        }
    }
}
