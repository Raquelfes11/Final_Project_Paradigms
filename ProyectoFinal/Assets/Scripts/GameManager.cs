using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // public TMP_Text collectblesNumbersText;
    private int colectiblesNumbers;

    // public TMP_Text totalCollectblesNumbersText;
    private int totalColectiblesNumbers;


    // Start is called before the first frame update
    void Start()
    {
        totalColectiblesNumbers = transform.childCount;
        // totalCollectblesNumbersText.text = totalColectiblesNumbers.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       if (transform.childCount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void AddColectible()
    {
        colectiblesNumbers++;
        // collectblesNumbersText.text = colectiblesNumbers.ToString();
    }
}
