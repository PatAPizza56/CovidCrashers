using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    GameObject endScreen;
    GameObject joystick;
    GameObject attackButton;
    GameObject completeScreen;
    GameObject finalCovid;
    public GameObject finalCovidError;
    public SFXScript sfx;

    private void Awake()
    {
        //Assign objects with tags
        endScreen = GameObject.FindGameObjectWithTag("EndScreen");
        joystick = GameObject.FindGameObjectWithTag("Joystick");
        attackButton = GameObject.FindGameObjectWithTag("AttackButton");
        completeScreen = GameObject.FindGameObjectWithTag("CompleteScreen");
        finalCovid = GameObject.FindGameObjectWithTag("FinalCovid");
        //Set objects "Inactive"
        if (endScreen != null)
        endScreen.transform.localScale = new Vector3(0, 0, 0);
        if(completeScreen != null)
        completeScreen.transform.localScale = new Vector3(0, 0, 0);
        if(joystick != null)
        joystick.transform.localScale = new Vector3(1, 1, 1);
        if(attackButton != null)
        attackButton.transform.localScale = new Vector3(1, 1, 1);
        if(finalCovid != null)
        {
            finalCovid.transform.localScale = new Vector3(.4f, .4f, 1);
        }
        

    }
    private void Update()
    {
        if(finalCovid != null && finalCovid.GetComponent<CovidHealth>().health <= 0)
        {
            Invoke("GameWon", 3);
        }
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        DontDestroyOnLoad(sfx);
    }

    public void LoadLevelMenu()
    {
        SceneManager.LoadScene(1);
        DontDestroyOnLoad(sfx);
    }

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            joystick.transform.localScale = new Vector3(0, 0, 0);
            attackButton.transform.localScale = new Vector3(0, 0, 0);
            endScreen.transform.localScale = new Vector3(1, 1, 1);
            sfx.LevelFailedRiffPlay();
        }
    }
    public void GameWon()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            joystick.transform.localScale = new Vector3(0, 0, 0);
            attackButton.transform.localScale = new Vector3(0, 0, 0);
            completeScreen.transform.localScale = new Vector3(1, 1, 1);
            sfx.LevelCompleteRiffPlay();
        }
        
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        DontDestroyOnLoad(sfx);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DontDestroyOnLoad(sfx);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);
        DontDestroyOnLoad(sfx);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(3);
        DontDestroyOnLoad(sfx);
    }

}
