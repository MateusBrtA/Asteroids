using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    private Rigidbody rigidbody;
    
    private bool Andar;
    public float speed = 1.0f;
    
    private float Virar;
    public float virarSpeed = 1;

    Bordas xmin, xmax, ymin, ymax;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Andar = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Virar = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Virar = -1.0f;
        }
        else
        {
            Virar = 0.0f;
        }
    }

    private void FixedUpdate()
    {
        if (Andar)
        {
            rigidbody.AddForce(this.transform.forward * speed);
        }
     //  if (Virar != 0.0f)
     //  {
     //      rigidbody.AddTorque(Virar *);
     //  }
    }

   // public void Teleporte()
   // {
   //     if (transform.position.x < xmin)
   //     {
   //         transform.position = new Vector3(xmax, transform.position.y, transform.position.z);
   //     }
   //     else if (transform.position.x > xmax)
   //     {
   //         transform.position = new Vector3(xmin, transform.position.y, transform.position.z);
   //     }
   //
   //     if (transform.position.y < ymin)
   //     {
   //         transform.position = new Vector3(transform.position.x, ymax, transform.position.z);
   //     }
   //     else if (transform.position.y > ymax)
   //     {
   //         transform.position = new Vector3(transform.position.x, ymin, transform.position.z);
   //     }
   // }
}
