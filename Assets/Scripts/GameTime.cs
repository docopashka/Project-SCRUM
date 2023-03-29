using System.Collections;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class GameTime : MonoBehaviour
{
    private Text _textTime;
    private int hour, min, sec;
    private string h, m, s;
    private static GameTime _inst;

    void Awake()
    {
        _inst = this;
        _textTime = GetComponent<Text>();
        StartCoroutine(RepeatingFunction());
    }

    public static void StopTime()
    {
        _inst.Stop_inst();
    }

    public static void StartTime()
    {
        _inst.Start_inst();
    }

    void Stop_inst()
    {
        StopAllCoroutines();
        sec = 0;
        min = 0;
        hour = 0;
        _textTime.text = "00:00:00";
    }

    void Start_inst()
    {
        StartCoroutine(RepeatingFunction());
    }

    IEnumerator RepeatingFunction()
    {
        while (true)
        {
            TimeCount();
            yield return new WaitForSeconds(1);
        }
    }

    void TimeCount()
    {
        if (sec > 59)
        {
            sec = 0;
            min++;
        }
        if (min > 59)
        {
            min = 0;
            hour++;
        }
        if (hour > 23)
        {
            hour = 0;
        }

        if (sec < 10) s = "0" + sec; else s = sec.ToString();
        if (min < 10) m = "0" + min; else m = min.ToString();
        if (hour < 10) h = "0" + hour; else h = hour.ToString();

        sec++;

        _textTime.text = m + ":" + s;//h + ":" + 
    }
}