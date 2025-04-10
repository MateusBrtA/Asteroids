using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private Rigidbody rigidbody;
    public float speed = 10.0f;
    public float tamanho = 1.0f;
    public float maxTamanho = 0.5f;
    public float minTamanho = 1.5f;
    public float destroiAsteroide = 20.0f;
    public float variaTrajetoria = 15.0f;
    public GameObject[] powerups;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.tamanho;
        rigidbody.mass = this.tamanho;
    }
    public void Trajetoria(Vector3 direction)
    {
        rigidbody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.destroiAsteroide);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tiro")
        {
            if ((this.tamanho * 0.5f) >= this.minTamanho)
            {
               Metadinha();
               Metadinha();
            }
            if (this.tamanho < 0.7f)
            {
                DropItem();
            }
            FindObjectOfType<GameCC>().DestroiAsteroide(this);
            Destroy(this.gameObject);
        }
        if (other.tag == "TiroInimigo")
        {
            if ((this.tamanho * 0.5f) >= this.minTamanho)
            {
                Metadinha();
                Metadinha();
            }
            if (this.tamanho < 0.7f)
            {
                DropItem();
            }
            FindObjectOfType<GameCC>().DestroiAsteroide(this);
            Destroy(this.gameObject);
        }
    }

    private void Metadinha()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;
   
        Asteroide metade = Instantiate(this, position, this.transform.rotation);
        metade.tamanho = this.tamanho * 0.5f;
        metade.Trajetoria(Random.insideUnitCircle.normalized * this.speed);
    }

    public void DropItem()
    {
        float chance = Random.Range(0f, 1f);

        if (chance > 0.8f)
        {
            Instantiate(powerups[Random.Range(0, 5)], transform.position, transform.rotation);
        }
    }

    // private void Metadinha()
    // {
    //     Vector3 position = new Vector3 (transform.position.x + Random.insideUnitCircle.x * 0.5f, transform.position.y + Random.insideUnitCircle.y * 0.5f,0);
    //
    //     GameObject metade = Instantiate(this.gameObject, position, transform.rotation);
    //     Vector2 direction = Random.insideUnitCircle;
    //     metade.GetComponent<Asteroide>().tamanho = tamanho / 2;
    //
    //     Vector3 SpawnDir = Random.insideUnitCircle.normalized * this.;
    //     Vector3 SpawnAst = this.transform.position + SpawnDir;
    //
    //     float varia = Random.Range(-this.variaTrajetoria, this.variaTrajetoria);
    //     Quaternion rotation = Quaternion.AngleAxis(varia, Vector3.forward);
    // }

}
