using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int score = 0;

    private const string FILE_DEATHS = "/Logs/totalDeaths.txt";

    string FILE_PATH_TOTAL_DEATHS; 
    
    const string PREF_KEY_TOTAL_DEATHS = "TotalDeathsKey";

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public int targetscore = 3;

    public Text text;

    public int currentLevel = 0;

    private int totalDeaths = -1;

    private int deaths = 0;

    public int Deaths
    {
        get { return deaths; }
        set
        {
            deaths = value;
            if (deaths > 0)
            {
                TotalDeaths ++;
            }
        }
        
    }

    public int TotalDeaths
    {
        get
        {
            if (totalDeaths < 0)
            {
                //totalDeaths = PlayerPrefs.GetInt(PREF_KEY_TOTAL_DEATHS, 0);
                string fileContents = File.ReadAllText(FILE_PATH_TOTAL_DEATHS);
                totalDeaths = Int32.Parse(fileContents);

            }   
            return totalDeaths;
        }
        set
        {
            totalDeaths = value;
            //PlayerPrefs.SetInt(PREF_KEY_TOTAL_DEATHS, totalDeaths);
            File.WriteAllText(FILE_PATH_TOTAL_DEATHS, totalDeaths + "");
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        FILE_PATH_TOTAL_DEATHS = Application.dataPath + FILE_DEATHS;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Level: " + currentLevel +
                    "\nScore: " + Score +
                    "\nTarget: " + targetscore +
                    "\nTotal deaths: " + TotalDeaths +
                    "\nDeaths: " + Deaths;
        
        if (score == targetscore)
        {
            currentLevel++;
            GetComponent<AudioSource>().Play();
            targetscore += targetscore + targetscore/2;
        }
    }
}
