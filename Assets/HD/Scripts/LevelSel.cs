using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSel : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //Player.isDead = false;
        //Player.isWin = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMenu()
    {
        //Application.LoadLevel(0);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Application.LoadLevel(Application.loadedLevel);
        Application.LoadLevel(3);
    }

    public void LoadHowtoPlay()
    {
        Application.LoadLevel(1);
    }

    public void LoadGame()
    {
        Application.LoadLevel(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
