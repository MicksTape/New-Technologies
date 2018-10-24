using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("blueWins", 0);
        PlayerPrefs.SetInt("redWins", 0);
    }

    void Update()
    {
        if (Input.GetButton("Interact1") || Input.GetButton("Interact2"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
