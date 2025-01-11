using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class PasswordHandler : MonoBehaviour
{
    public InputField passwordInputField; // Arrastra el InputField desde el inspector
    public GameObject passwordCanvas; // Arrastra el canvas desde el inspector
    public string correctPassword = "PARADIGMAS"; // Define la contraseña correcta
    public string minigameSceneName = "Scenes/Minigame1"; // Define el nombre de la escena del minijuego

    public void CheckPassword()
    {
        if (passwordInputField.text.ToUpper() == correctPassword)
        {
            Debug.Log("Contraseña correcta. Cargando el minijuego...");
            SceneManager.LoadScene(minigameSceneName);
        }
        else
        {
            Debug.Log("Contraseña incorrecta. Inténtalo de nuevo.");
            passwordInputField.text = ""; // Limpia el campo de texto
        }
    }

    public void CloseCanvas()
    {
        passwordCanvas.SetActive(false); // Cierra el canvas si el jugador decide salir
    }
}
