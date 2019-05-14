﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabContentAlunos : MonoBehaviour
{
    public TextMeshProUGUI nome;
    public Image portrait;
    public TextMeshProUGUI description;
    public void SetAluno(ClassAluno aluno)
    {
        nome.SetText(aluno.nome);
        portrait.sprite = aluno.LoadPortrait();
        description.SetText(aluno.descricao);

    }
}