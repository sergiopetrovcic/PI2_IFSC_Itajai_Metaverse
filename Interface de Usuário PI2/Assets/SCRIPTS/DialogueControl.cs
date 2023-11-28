using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject Estágio;
    public GameObject AEstudantil;
    public GameObject Requerimentos;
    public GameObject SecVirtual;
    public GameObject dialogueObj;
    public Image profile;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;




    public void Speech(Sprite p, string[] txt, string actorName)
    {
        SecVirtual.SetActive(false);
        dialogueObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        actorNameText.text = actorName;
        StartCoroutine(TypeSentence());
    }
    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
     }

    public void NextSentence()
    {
        if (speechText.text == sentences[index])
        {

            //Ainda há textos
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else //lido quando os textos acabam
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
            }
        }
        return;
    }
    public void AbrirEstágio()
    {
        dialogueObj.SetActive(false);
        Estágio.SetActive(true);
    }

    public void FecharEstágio()
    {
        Estágio.SetActive(false);
        dialogueObj.SetActive(true);
    }
    public void AbrirAssEstudantil()
    {
        dialogueObj.SetActive(false);
        AEstudantil.SetActive(true);
    }

    public void FecharAssEstudantil()
    {
        AEstudantil.SetActive(false);
        dialogueObj.SetActive(true);
    }

    public void AbrirRequerimentos()
    {
        dialogueObj.SetActive(false);
        Requerimentos.SetActive(true);
    }

    public void FecharRequerimentos()
    {
        Requerimentos.SetActive(false);
        dialogueObj.SetActive(true);
    }

    public void FecharChatBot()
    {
        dialogueObj.SetActive(false);
    }
}
