using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectible : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            FindAnyObjectByType<GameManager>().AddColectible();
            Destroy(gameObject);
        }
    }
}
