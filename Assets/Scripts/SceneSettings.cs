using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSettings : MonoBehaviour
{
    [SerializeField] GameObject _background;
    private void Start()
    {
        _background.SetActive(false);
    }
    private void Update()
    {
        if(TrainCounter._allTrains <= 0)
        {
            Debug.Log("that's all");
            _background.SetActive(true);
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
