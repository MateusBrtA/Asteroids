using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaFase : MonoBehaviour
{
    [SerializeField] string Fase;
    [SerializeField] private GameObject boss;


    public void Mudafase()
    {
        SceneManager.LoadScene(Fase);
    }

}
