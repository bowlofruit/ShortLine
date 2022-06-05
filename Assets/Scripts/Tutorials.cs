using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorials : MonoBehaviour
{
    [SerializeField] GameObject _background;
    private int _count;

    private void Start()
    {
        _background.SetActive(false);
        _count = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Train"))
        {
            _background.SetActive(true);
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
    public void Next()
    {
        _count++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + _count);       
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
