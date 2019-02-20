﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public TextAsset DialogosJson;
    public TextAsset AcoesJson;

    // Start is called before the first frame update
    void Start()
    {
        Game.Setup();
        try
        {
            JsonUtility.FromJsonOverwrite(DialogosJson.text, Game.Dialogs);
            JsonUtility.FromJsonOverwrite(AcoesJson.text, Game.Actions);
        }
        catch (Exception e) {
            Debug.LogException(e);
        }
    }


}
