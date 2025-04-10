using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speed;
    public string type;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        Mover();
    }

    private void Mover()
    {
        transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
    }
}
