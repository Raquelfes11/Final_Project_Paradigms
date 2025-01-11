using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneLoader : MonoBehaviour
{
    // Método que será llamado cuando se presione el botón
    public void LoadScapeRoomScene()
    {
        SceneManager.LoadScene("ScapeRoom");
    }
}

