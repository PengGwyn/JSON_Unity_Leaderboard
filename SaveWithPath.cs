using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveWithPath : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameField;

    private FileHandler _fileHandler;

    private void Awake()
    {
        _fileHandler = GetComponent<FileHandler>();
    }

    public void SaveData(string path)
    {
        _fileHandler.SaveAddToJson(usernameField, path);
    }
}
