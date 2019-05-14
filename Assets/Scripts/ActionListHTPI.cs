﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ActionListHTPI : ActionList
{
    protected HTPIController htpiController;

    private new void Awake()
    {
        base.Awake();
    
        htpiController = FindObjectOfType<HTPIController>();
        if (htpiController == null)
        {
            Debug.Log("Não foi possivel encontrar o HTPIController");
        }
     

    }


    protected override void OnSelect(ClassAcao acao)
    {
        if (htpiController != null)
            htpiController.AddAction(acao);
    }
}