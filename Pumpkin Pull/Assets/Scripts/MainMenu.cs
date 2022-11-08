using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // script for scene control
    [SerializeField] private string firstLevel;
    [SerializeField] private string secondLevel;
    [SerializeField] private string thirdLevel;
    [SerializeField] private string fourthLevel;
    [SerializeField] private string fifthLevel;
    [SerializeField] private string tutorialScreen;
    [SerializeField] private string gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(tutorialScreen);
    }

    public void Proceed()
    {
        SceneManager.LoadScene(firstLevel);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(gameOver);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
 
}
