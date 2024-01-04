using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private int sec = 0;
    private int min = 0;
    public Text timerLabel;
    private int delta = 0;
    //[SerializeField] private int delta = 0;

    void Start()
    {
        timerLabel.text = "Time: " + min.ToString("D2") + " : " + sec.ToString("D2");
        StartCoroutine(TimeFlow());
    }

    /*private void Update()
    {
        StopAllCoroutines();
    }*/

    IEnumerator TimeFlow()
    {
        while (true)
        {
            if (sec == 59)
            {
                min++;
                sec -= 1;
            }
            sec += delta;
            timerLabel.text = "Time: " + min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }

    public void StartTimer(int delta)
    {
        this.delta = delta;
    }
}
