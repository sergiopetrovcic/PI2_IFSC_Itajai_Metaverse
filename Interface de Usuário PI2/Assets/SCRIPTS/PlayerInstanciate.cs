using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstanciate : MonoBehaviour
{
    public GameObject[] personagens; // Certifique-se de configurar os prefabs corretamente no Inspetor.

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("SelectedGender"))
        {
            Debug.LogError("A chave 'SelectedGender' não está definida em PlayerPrefs.");
            //return;
        }

        //int selectedGender = PlayerPrefs.GetInt("SelectedGender", 0);
        PlayerPrefs.SetInt("SelectedGender", 0);
        int selectedGender = 0;
        Debug.Log("SelectedGender: " + selectedGender);

        if (selectedGender >= 0 && selectedGender < personagens.Length)
        {
            GameObject character = Instantiate(personagens[selectedGender], transform.position, Quaternion.identity);
           
            DontDestroyOnLoad(character);
        }
        else
        {
            Debug.LogError("Índice de gênero selecionado fora dos limites.");
        }
    }
}
