using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoBoss : MonoBehaviour
{
    [SerializeField] private GameObject Boss;

    public void CriaBoss()
    {
        Instantiate(Boss, transform.position, transform.rotation);

        Destroy(gameObject);
    }

}
