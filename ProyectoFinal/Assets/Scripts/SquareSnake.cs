using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para cambiar de escena
using UnityEngine.UI; // Para mostrar mensajes en pantalla

public class SquareSnake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    private List<Transform> _segments;
    public Transform segmentPrefab;

    private int foodEaten = 0;

    public Text messageText; 

    private void Start()
    {
        foodEaten = 0;
        Time.timeScale = 1;
        _segments = new List<Transform>();
        _segments.Add(this.transform);

        // Ocultar mensaje al inicio
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + _direction.x, Mathf.Round(this.transform.position.y) + _direction.y, 0.0f);
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);

        // Incrementar el contador de comida
        foodEaten++;

        // Verificar si se alcanzaron 4 comidas
        if (foodEaten >= 4)
        {
            EndGame();
        }
    }

    private void ResetState()
    {
        foodEaten = 0;

        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);

        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SquareFood")
        {
            Grow();
        }

        if (other.tag == "SquareWall")
        {
            ResetState();
        }
    }

    private void EndGame()
    {
        // Mostrar mensaje
        if (messageText != null)
        {
            messageText.gameObject.SetActive(true);
        }

        // Pausar el juego
        Time.timeScale = 0;

        // Cambiar de escena después de 3 segundos
        StartCoroutine(ChangeSceneAfterDelay());
    }

    private IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSecondsRealtime(3); // Tiempo real (ignora el timeScale)
        SceneManager.LoadScene("Scenes/ScapeRoom"); 
    }
}
