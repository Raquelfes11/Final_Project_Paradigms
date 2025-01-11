using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneLoaderFinal : MonoBehaviour
{
    // Método que será llamado cuando se presione el botón
    public void LoadScapeRoomScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

