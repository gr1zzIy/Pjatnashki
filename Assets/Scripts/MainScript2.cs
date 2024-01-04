using UnityEngine;
using Board;
using UnityEngine.UI;
using Color = UnityEngine.Color;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using System.Collections;
using System.Threading;
using UnityEngine.SceneManagement;

public class ControllerForAlphabet : MonoBehaviour
{
    Game game;
    Sound sound;
    System.Random rand = new System.Random();

    const int size = 4;

    public int LastScore;
    public Text TextMoves;
    public Text LastMoves;
    public Text timerLabel;

    private int sec = 0;
    private int min = 0; 
    private int delta = 0;

    void Start()
    {
        game = new Game(size);
        sound = GetComponent<Sound>();

        LastScore = PlayerPrefs.GetInt("LastScore");

        HideButtons();
        StartCoroutine(TimeFlow());
    }

    public void OnStart()
    {
        game.Start(rand.Next(1, 2000));
        //game.Start(10);

        sound.PlayStart();

        delta = 1;
        sec = 0;
        min = 0;

        ShowButtons();
    }

    public void PauseResumeButtons()
    {
        sound.PlayMove();
    }

    public void ExitButton()
    {
        sound.PlayGoodbye();
        Thread.Sleep(1500);
        Application.Quit();
    }
    
    public void OnClick()
    {
        if (game.Solved())
            return;

        string name = EventSystem.current.currentSelectedGameObject.name;
        int x = int.Parse(name.Substring(0, 1));
        int y = int.Parse(name.Substring(1, 1));

        if (game.PressAt(x, y) > 0)
            sound.PlayMove();

        ShowButtons();
        if (game.Solved())
        {
            LastScore = game.moves;
            PlayerPrefs.SetInt("LastScore", LastScore);

            delta = 0;
            sec = 0;
            min = 0;
            StopCoroutine(TimeFlow());

            TextMoves.text = $"Game finished in {game.moves} moves";

            if (game.moves < 50)
            {
                sound.PlaySolved2();
            }
            else
            {
                sound.PlaySolved();
            } 

            HideButtons();     
        }
            
    }

    private void HideButtons()
    {
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
                ShowDigitAt(0, x, y);

        var labelMoves = GameObject.Find("LastMoves");
        var labelTextMoves = labelMoves.GetComponentInChildren<Text>();
        labelTextMoves.text = "last moves: " + LastScore + " moves";
    }

    private void ShowButtons()
    {
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
                ShowDigitAt(game.GetDigitAt(x, y), x, y);

        LastMoves.text = "last moves: " + LastScore + " moves";
        TextMoves.text = game.moves + " moves";
    }

    private void ShowDigitAt(int digit, int x, int y)
    {
        string name = $"{x}{y}";
        var button = GameObject.Find(name);
        var text = button.GetComponentInChildren<Text>();
        //text.text = Dec(digit);// Available only numbers
        text.text = DecToHex(digit); // Available letters + numbers
        button.GetComponentInChildren<UnityEngine.UI.Image>().color = // set visible
            (digit > 0) ? Color.white : Color.clear;
    }

    private string Dec(int digit)
    {
        if (digit == 0) return "";
        return digit.ToString();
    }

    private string DecToHex(int digit)
    {
        /*if (digit == 0) return "";
        if (digit < 10) return digit.ToString();
        return ((char)('A' + digit - 10)).ToString();*/

        switch (digit)
        {
            case 1:
                return "A";
            case 2:
                return "B";
            case 3:
                return "C";
            case 4:
                return "D";
            case 5:
                return "E";
            case 6:
                return "F";
            case 7:
                return "G";
            case 8:
                return "H";
            case 9:
                return "I";
            case 10:
                return "J";
            case 11:
                return "K";
            case 12:
                return "L";
            case 13:
                return "M";
            case 14:
                return "N";
            case 15:
                return "O";
            default:
                return "";
        }
    }

    IEnumerator TimeFlow()
    {
        while (true)
        {
            if (sec == 59)
            {
                min++;
                sec = 0;
            }
            sec += delta;
            timerLabel.text = "Time: " + min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }

    public void BackToMenu()
    {
        sound.PlayMove();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
