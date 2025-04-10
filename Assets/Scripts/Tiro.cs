using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    [SerializeField]
    float speed = 20;
    private Rigidbody rigidbody;
    [SerializeField]
    private float destroitiro = 3f;
    [SerializeField] private GameObject explosao;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.linearVelocity = transform.up * speed;
        Destroy(gameObject, destroitiro);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroide")
        {
            Destroy(this.gameObject);
        }
    }


}
