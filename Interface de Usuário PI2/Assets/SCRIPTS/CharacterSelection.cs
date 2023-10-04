using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject masculinoCharacterPrefab;
    public GameObject femininoCharacterPrefab;

    public Transform spawnPoint;

    private GameObject[] characterList;

    private string selectedGender; 

    
    private void Start()
    {
        characterList = new GameObject[2];
        UpdateCharacterPanels();

        for (int i = 0; i < 2; i++)
            characterList[i] = transform.GetChild(i).gameObject;

        foreach (GameObject go in characterList)
            go.SetActive(false);

        if (characterList[0])
            characterList[0].SetActive(true);

        CharacterList.Instance.SelectedCharIndex = 0;

        selectedGender = PlayerPrefs.GetString("SelectedGender", "Masculino");
    }

    public void SelecionarButton()
    {
        
        if (selectedGender == "Masculino")
        {
            PlayerPrefs.SetInt("SelectedGender", 0); 
        }
        else if (selectedGender == "Feminino")
        {
            PlayerPrefs.SetInt("SelectedGender", 1); 
        }
        PlayerPrefs.Save(); 

        PlayerPrefs.SetInt("CharacterSelected", CharacterList.Instance.SelectedCharIndex);
        SceneManager.LoadScene("Jogo");
    }

    [SerializeField] CharacterPanel characterPanelLeft;

    [SerializeField] CharacterPanel characterPanelRight;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CharacterList.Instance.SelectedCharIndex++;
            Debug.Log("left");
            UpdateCharacterPanels();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CharacterList.Instance.SelectedCharIndex--;
            Debug.Log("right");
            UpdateCharacterPanels();
        }
    }

    private void UpdateCharacterPanels()
    {
        characterPanelLeft.UpdateCharacterPanel(CharacterList.Instance.GetPrevious());
        characterPanelRight.UpdateCharacterPanel(CharacterList.Instance.GetNext());

        if (selectedGender == "1")
        {
            characterPanelRight.gameObject.SetActive(true);
            characterPanelLeft.gameObject.SetActive(false);
        }
        else if (selectedGender == "0")
        {
            characterPanelLeft.gameObject.SetActive(true);
            characterPanelRight.gameObject.SetActive(false);
        }
    }
}