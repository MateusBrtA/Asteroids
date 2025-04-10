using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private float CooldownTiro = 1f;
    
    [SerializeField] Transform SpawnTiro;

    [SerializeField] private GameObject TiroInimigo;

    [SerializeField] protected GameObject powerup;
    
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CooldownTiro -= Time.deltaTime;
        if (CooldownTiro <= 0)
        {
            Instantiate(TiroInimigo, SpawnTiro.position, SpawnTiro.rotation);
            CooldownTiro = 2f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
                 
        if (other.gameObject.CompareTag("Tiro"))
        {
            DropItem();
        }
    }

    public void DropItem()
    {
        float chance = Random.Range(0f, 1f);

        if (chance > 0.8f)
        {
            Instantiate(powerup, transform.position, transform.rotation);
        }
    }

}
