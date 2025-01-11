using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System.IO; 


public class MinigameCompletion : MonoBehaviour
{
    [SerializeField] private string keyword = "Clave: OCTOPUS"; // La palabra clave que se mostrará
    [SerializeField] private string mainSceneName = "Scenes/ScapeRoom"; // Nombre de la escena principal
    [SerializeField] private float displayTime = 3f; // Tiempo que se muestra la palabra clave

    [SerializeField] private Text keywordText; // Campo de texto en el Canvas para mostrar la clave

    void Start()
    {
        keywordText.gameObject.SetActive(false); // Oculta el texto al inicio
    }

    public void CompleteMinigame()
    {
        StartCoroutine(ShowKeywordAndReturn());
    }

    private IEnumerator ShowKeywordAndReturn()
    {
        // Muestra la palabra clave
        keywordText.text = keyword;
        keywordText.gameObject.SetActive(true);

        // Espera el tiempo configurado
        yield return new WaitForSeconds(displayTime);

        // Regresa a la escena principal
        SceneManager.LoadScene(mainSceneName);
    }
}

