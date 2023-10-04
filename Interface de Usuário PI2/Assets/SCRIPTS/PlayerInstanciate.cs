using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstanciate : MonoBehaviour
{
    public GameObject[] personagens;
    public GameObject masculinoCharacterPrefab;
    public GameObject femininoCharacterPrefab;

    private void Awake()
    {
        int selectedGender = PlayerPrefs.GetInt("SelectedGender", 0); 

        
        Debug.Log("SelectedGender: " + selectedGender);

        if (selectedGender >= 0 && selectedGender < personagens.Length)
        {
            Instantiate(personagens[selectedGender], transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Índice de gênero selecionado fora dos limites.");
        }
    }



}