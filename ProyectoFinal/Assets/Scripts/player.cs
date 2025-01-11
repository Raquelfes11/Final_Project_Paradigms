using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Para manejar elementos de UI

public class player : MonoBehaviour
{
    public float jumpForce = 10f; // Height that we are going to jump

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color colorBlue;
    public Color colorYellow;
    public Color colorPurple;
    public Color colorPink;

    public Text messageText; 

    void Start()
    {
        SetRandomColor();

        // Ocultar el texto al inicio
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "change")
        {
            SetRandomColor();
            Destroy(collider.gameObject);
            return;
        }

        if (collider.tag == "finish")
        {
            FinishGame(); // Llama a la función que maneja el final del juego
            return;
        }

        if (collider.tag != currentColor)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "blue";
                sr.color = colorBlue;
                break;

            case 1:
                currentColor = "yellow";
                sr.color = colorYellow;
                break;

            case 2:
                currentColor = "purple";
                sr.color = colorPurple;
                break;

            case 3:
                currentColor = "pink";
                sr.color = colorPink;
                break;
        }
    }

    void FinishGame()
    {
        // Detener el tiempo
        Time.timeScale = 0;

        // Mostrar mensaje en pantalla
        if (messageText != null)
        {
            messageText.gameObject.SetActive(true);
        }

        // Cambiar de escena después de 3 segundos
        StartCoroutine(ChangeSceneAfterDelay());
    }

    IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSecondsRealtime(3); // Usa tiempo real (ignora Time.timeScale = 0)
        SceneManager.LoadScene("Scenes/ScapeRoom"); 
    }
}
