using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using File = System.IO.File;
using Unity.VisualScripting;
using UnityEditor;
using Application = UnityEngine.Application;
using System;
using System.Linq;
using UnityEngine.WSA;
using Input = UnityEngine.Input;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshPro displayText;
    public TextMeshPro highScoreListText;
    private int score = 0;
    public GameObject gameOverScreen;

    public List<int> highScore = new List<int>();
    private string File_Path;
    private const string File_Dir = "/Data/";
    private const string File_Name = "highScore.txt";
    
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    private void Awake()
    {
        if (Instance==null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Directory.CreateDirectory(Application.dataPath+File_Dir);
        File_Path = Application.dataPath + File_Dir + File_Name;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        displayText.text
            = "Your Score:" + score;
        
    }

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverScreen.SetActive(false);
        score = 0;
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        UpdateHighScore();
        AssetDatabase.Refresh();
        
    }

    public void UpdateHighScore()
    {
        if (highScore.Count==0)
        {
            string fileContent = File.ReadAllText(File_Path);
            string[] fileSplit = fileContent.Split("\n");
            
            for (int i = 1; i < fileSplit.Length-1; i++)
            {
                highScore.Add(Int32.Parse(fileSplit[i]));
                
            }
            
        }

        for (int i = 0; i < highScore.Count; i++)
        {
            if (highScore[i]<Score)
            {
                highScore.Insert(i,Score);
                break;
            }
        }

        highScore.RemoveRange(3,highScore.Count-4);

        string highScoreStr = "High Score:\n";
        
        for (int i = 0; i < highScore.Count; i++)
        {
            highScoreStr += highScore[i] + "\n";
        }

        highScoreListText.text = highScoreStr;

        File.WriteAllText(File_Path,highScoreStr);
    }
    
    
    
    
    
}
