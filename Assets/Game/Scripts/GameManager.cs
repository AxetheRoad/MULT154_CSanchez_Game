using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOver;


    public Button Restart;
    public bool gameActive = false;
    private GameManager gameManager;
    public GameObject titleScreen;
    public GameObject settingsScreen;
    public GameObject EndTitle;
   


    AudioSource audioSorce;
    public const string VOLUME_LEVEL_KEY = "VolumeLevel";
    public const float DEFAULT_VOLUME = 0.5f;


    // Start is called before the first frame update
    void Start()
    {


        settingsScreen.gameObject.SetActive(false);
        EndTitle.gameObject.SetActive(false);

        audioSorce = GetComponent<AudioSource>();

        float volume = PlayerPrefs.GetFloat(VOLUME_LEVEL_KEY, DEFAULT_VOLUME);
        audioSorce.volume = volume;

        DontDestroyOnLoad(gameObject);

      //  foreach (Damage.EnemyDamage damage in System.Enum.GetValues(typeof(Damage.EnemyDamage)))
        {
            //(damage, 0);
        }
    }

    public void StartGame()
    {
        gameActive = true;
        titleScreen.gameObject.SetActive(false);
        SceneManager.LoadScene("Main");

        //Damage difficulty = GetComponent<Damage>();


    }

    public void GameOver()
    {
        SceneManager.LoadScene("Menu");
        // gameOver.gameObject.SetActive(true);
        //Restart.gameObject.SetActive(true);


    }


    public void Settings()
    {
        titleScreen.gameObject.SetActive(false);
        settingsScreen.gameObject.SetActive(true);
    }
    public void Return()
    {
        titleScreen.gameObject.SetActive(true);
        settingsScreen.gameObject.SetActive(false);
        EndTitle.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Adjustvolume(float level)
    {
        audioSorce.volume = level;
        PlayerPrefs.SetFloat("VolumeLevel", level);
    }
    public void Exit()
    {
        Application.Quit();

    }
    // Update is called once per frame
    void Update()
    {
    
    }


}
