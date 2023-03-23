using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataWithPath : MonoBehaviour
{
    private FileHandler _fileHandler;
    private LeaderboardManager _leaderboardManager;
    
    private void Awake()
    {
        _fileHandler = GetComponent<FileHandler>();
        _leaderboardManager = FindObjectOfType<LeaderboardManager>();
    }

    public void LoadFromJson(string path)
    {
        _fileHandler.LoadJson(path);
        _leaderboardManager.InstantiateLeaderBoardItems();
    }
}
