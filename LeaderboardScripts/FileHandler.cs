using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class FileHandler : MonoBehaviour
{
    public Leaderboards LB = new Leaderboards();

    //public string path;

    public void SaveAddToJson(TMP_InputField usernameField, string path)
    {
        if (File.Exists(Application.dataPath + path))
        {
            string _json = File.ReadAllText(Application.dataPath + path);
            Leaderboards lData = JsonUtility.FromJson<Leaderboards>(_json);
            
            lData.names.Add(usernameField.text);
            lData.scores.Add(int.Parse(ScoreManager.Instance.score.ToString()));
            
            string json = JsonUtility.ToJson(lData, false);
            File.WriteAllText(Application.dataPath + path, json);
            Debug.Log("Data added");
        }
        else
        {
            // we create it
            Leaderboards leadBoards = new Leaderboards();
            leadBoards.names.Add(usernameField.text);
            leadBoards.scores.Add(int.Parse(ScoreManager.Instance.score.ToString()));

            string json = JsonUtility.ToJson(leadBoards, false);
            File.WriteAllText(Application.dataPath + path, json);
            Debug.Log("Data created");
        }  
        LoadJson(path);
    }

    public void LoadJson(string path)
    {
        if (File.Exists(Application.dataPath + path))
        {
            string json = File.ReadAllText(Application.dataPath + path);
            LB = JsonUtility.FromJson<Leaderboards>(json);
        }
        else
        {
            Debug.Log("File not found");
        }  
    }
}
