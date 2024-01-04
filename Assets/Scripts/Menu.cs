using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    Sound sound;
    public Text LastMoves;
    public int LastScore;

    void Start()
    {
        sound = GetComponent<Sound>();
        LastScore = PlayerPrefs.GetInt("LastScore");
        LastMoves.text = "last moves: " + LastScore + " moves";
    }

    /*public void LoadLevel()
    {
        sound.PlayStart();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);// в кавычках название сцены на которую осуществляется переход
    }*/

    public void LoadNumbersLevel()
    {
        sound.PlayStart();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadAlphabetLevel()
    {
        sound.PlayStart();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void ClickSound()
    {
        sound.PlayMove();
    }

    public void ExitGame()
    {
        sound.PlayGoodbye();
        Thread.Sleep(1500);
        Application.Quit();
    }
}