﻿using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Dialog : MonoBehaviour
{
    public string Name;
    public string Local;
    public List<string> Dialogs;
    public bool LoadFromJson;
    public List<AudioClip> DialogsAudio;
    public AudioSource audioSource;
    public TextMeshProUGUI textMesh;
    public float speed = 0.2f;
    public UnityEvent AtEndOfDialog;
    private Coroutine reveal = null;
    private int id = 0;
    private bool revealing;

    void Awake()
    {
        if(LoadFromJson && Game.Characters!=null)
            Dialogs = Game.Characters.personagens.Find(x => x.nome == Name).dialogos.Find(x => x.local == Local).frases;
    }
    void OnEnable()
    {
        id = 0;
        
        ShowNextDialog();
    }

    void Update()
    {
        // Press ENTER or SPACE to show next sentence
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            ShowNextDialog();

        // Press Q to repeat last sentence
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!revealing)
            {
                id--;
                ShowNextDialog();
            }
        }
    }

    public void ShowNextDialog()
    {
        if (reveal != null)
            StopCoroutine(reveal);

        if (revealing)
        {
            textMesh.maxVisibleCharacters = Dialogs[id].Length;
            id++;
            revealing = false;
            return;
        }

        if (Dialogs.Count > id)
        {
            audioSource.Stop();
            reveal = StartCoroutine(revealPhrase());
        }
        else
        {
            AtEndOfDialog.Invoke();
        }
    }

    IEnumerator revealPhrase()
    {
        revealing = true;
        if (DialogsAudio.Count >= id + 1)
        {
            audioSource.clip = DialogsAudio[id];
            audioSource.Play();
        }

        string phrase = Dialogs[id];
        textMesh.maxVisibleCharacters = 0;
        textMesh.SetText(phrase);
        int size = phrase.Length;
        while (textMesh.maxVisibleCharacters < size)
        {
            textMesh.maxVisibleCharacters++;
            yield return new WaitForSeconds(speed);
        }
        id++;
        revealing = false;
    }
}
