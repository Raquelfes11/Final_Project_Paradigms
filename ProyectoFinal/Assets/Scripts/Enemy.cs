using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;




public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;
    public float health = 4f;
    [SerializeField] private Text messageText; // Arrastra el objeto de texto en el Inspector
    
    public static int EnemiesAlive = 0;

    void Start()
    {
        EnemiesAlive++;
        Time.timeScale = 1;
    }

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.relativeVelocity.magnitude > health)//Information about the collision
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        EnemiesAlive--;

        if (EnemiesAlive <= 0)
        {
            // Llamar al método para regresar al escape room
            StartCoroutine(ReturnToEscapeRoom());
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    IEnumerator ReturnToEscapeRoom()
    {
        messageText.text = "WELL DONE! Secret Word: OCTOPUS"; // Muestra el mensaje
        messageText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f); // Espera 3 segundos
        SceneManager.LoadScene("Scenes/ScapeRoom");
    }



}

