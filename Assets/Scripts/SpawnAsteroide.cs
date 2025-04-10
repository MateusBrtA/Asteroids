using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroide : MonoBehaviour
{
    public float spawnrate = 1.0f;
    public int quantidade = 1;
    public Asteroide asteroide;
    public float spwndst = 12.0f;
    public float variaTrajetoria = 15.0f;
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnrate, this.spawnrate);
    }
    private void Spawn()
    {
        for (int i=0; i< this.quantidade; i++)
        {
            Vector3 SpawnDir = Random.insideUnitCircle.normalized * this.spwndst;
            Vector3 SpawnAst = this.transform.position + SpawnDir;

            float varia = Random.Range(-this.variaTrajetoria, this.variaTrajetoria);
            Quaternion rotation = Quaternion.AngleAxis(varia, Vector3.forward);

            Asteroide asteroide = Instantiate(this.asteroide, SpawnAst, rotation);
            asteroide.tamanho = Random.Range(asteroide.minTamanho, asteroide.maxTamanho);
            asteroide.Trajetoria(rotation * -SpawnDir);
        }
    }

}
