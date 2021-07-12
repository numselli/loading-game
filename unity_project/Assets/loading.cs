using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class loading : MonoBehaviour {
    public int prosess;
    public int time;
    public Slider Slider;
    public Text persent;
    public Text Timetext;

    public GameObject ltxt;
    public GameObject mbtn;
    public GameObject lbar;
    public GameObject ttext;
    public GameObject ptext;

    public Text timetxt;
    public int sec;
    public int min;
    public int h;
    public int day;
    public int week;

    public GameObject image;
    bool playing;

   
    public AudioClip[] clips;
    private AudioSource audiosource;

    void Timeplus()
    {
        sec += 1;
    }

    void Start()
    {
        InvokeRepeating("Timeplus", 0f, 1.5f);

        Application.runInBackground = true;
        playing = true;
        time = PlayerPrefs.GetInt("E",time);
        h = PlayerPrefs.GetInt("Hours", h);
        min = PlayerPrefs.GetInt("Minutes", min);
        sec = PlayerPrefs.GetInt("Seconds", sec);
        week = PlayerPrefs.GetInt("week", week);
        day = PlayerPrefs.GetInt("day", day);

        InvokeRepeating("E", 0f, .2f);
        audiosource = FindObjectOfType<AudioSource>();
        audiosource.loop = false;
        // AudioListener.volume = (PlayerPrefs.HasKey("soundsOn") && (PlayerPrefs.GetInt("soundsOn") != 1)) ? 0f : 1f;
    }
    private AudioClip GetrandomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }
    void E()
    {
        prosess ++;
    }
    public void On()
    {
        image.SetActive(true);
        ltxt.SetActive(false);
        mbtn.SetActive(false);
        lbar.SetActive(false);
        ptext.SetActive(false);

        ttext.SetActive(false);

    }
    public void Off()
    {
        image.SetActive(false);
        ltxt.SetActive(true);
        mbtn.SetActive(true);
        ptext.SetActive(true);

        lbar.SetActive(true);
        ttext.SetActive(true);

    }
    public void Exit()
    {
        Application.Quit();
    }
    // public void SoundsClicked()
    // {
    //     bool flag = !PlayerPrefs.HasKey("soundsOn") || (PlayerPrefs.GetInt("soundsOn") == 1);
    //     flag = !flag;
    //     PlayerPrefs.SetInt("soundsOn", !flag ? 0 : 1);
    //     AudioListener.volume = !flag ? 0f : 1f;
    // }
    private void Update()
    {
        Slider.value = prosess;
        persent.text = prosess.ToString() + " %";
        if (prosess >= 101)
        {
            prosess = 0;
            time++;
        }

        timetxt.text = "loaded " + time.ToString() + " Times, " + "You have wasted " + week + " Weeks, " + day + " Days, " + h + " Hours, " + min + " Minutes, " + sec + " Seconds";

        if (!audiosource.isPlaying)
        {
            audiosource.clip = GetrandomClip();
            audiosource.Play();
        }
        if (FindObjectOfType<ColorChange>().t >= 2.000000)
        {
            FindObjectOfType<ColorChange>().Start();
            FindObjectOfType<ColorChange>().t = 0;
        }
        if (sec >= 60)
        {
            min++;
            sec = 0;
        }
        if (min >= 60)
        {
            h++;
            min = 0;
        }
        if (h >= 24)
        {
            day++;
            h = 0;
        }
        if (day >= 7)
        {
            week++;
            day = 0;
        }

    }
    void OnApplicationQuit()
    {       
            PlayerPrefs.SetInt("E",time);
            PlayerPrefs.SetInt("Hours", h);
            PlayerPrefs.SetInt("Minutes", min);
            PlayerPrefs.SetInt("Seconds", sec);
            PlayerPrefs.SetInt("week", week);
            PlayerPrefs.SetInt("day", day);
    }

}