﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// a class to initialise the current game save
public class SaveSetup : MonoBehaviour {

    private void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGame.gd"))
        {
            SaveLoad.Load();
            Game.current = SaveLoad.savedGame;
        }
        else
        {
            Game.current = new Game();
            SaveLoad.Save();
        }
    }
}