using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public RectTransform spawnPoint;

    public List<GameObject> items = new List<GameObject>();
    private List<int> _lastScores = new List<int>();

    private FileHandler _fileHandler;

    private void Awake()
    {
        _fileHandler = FindObjectOfType<FileHandler>();
    }

    public void InstantiateLeaderBoardItems()
    {
        RemoveAllFromList();
        foreach (int score in _fileHandler.LB.scores)
        {
            _lastScores.Add(score);
        }
        
        _fileHandler.LB.scores.Sort((x, y) => y.CompareTo(x));
        
        Debug.Log(_lastScores.Count);
        
        for (int i = 0; i < _fileHandler.LB.scores.Count; i++)
        {
            bool itemInstantiated = false;
            for (int j = 0; j < _lastScores.Count; j++)
            {
                if (_lastScores[j] == _fileHandler.LB.scores[i])
                {
                    // Check if item has already been instantiated
                    if (itemInstantiated) {
                        break;
                    }
            
                    GameObject newItem = Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
                    items.Add(newItem);
                    newItem.transform.SetParent(spawnPoint, false);
                    LeaderboardItem lb = newItem.GetComponent<LeaderboardItem>();
                    lb.userNameTxt.text = _fileHandler.LB.names[j];
                    lb.scoreTxt.text = _fileHandler.LB.scores[i].ToString();
            
                    // Mark item as instantiated
                    itemInstantiated = true;
                }
            }
        }
    }

    private void RemoveAllFromList()
    {
        foreach (GameObject item in items)
        {
            Destroy(item);
        }
        
        items.Clear();
        _lastScores.Clear();
    }
}
