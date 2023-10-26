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
    }
    public void SelecionarButton()
    {
        // Salva a escolha do gênero nas PlayerPrefs
        int selectedGender = CharacterList.Instance.SelectedCharIndex;
        PlayerPrefs.SetInt("SelectedGender", selectedGender);
        PlayerPrefs.Save();

        // Desativa os personagens na cena de seleção
        for (int i = 0; i < characterList.Length; i++)
        {
            characterList[i].SetActive(false);
        }

        // Carrega a próxima cena
        SceneManager.LoadScene("Jogo");
    }



    [SerializeField] CharacterPanel characterPanelLeft;
    [SerializeField] CharacterPanel characterPanelRight;

    void Update()
    {

        // Obtém o valor de selectedGender das PlayerPrefs
        int selectedGender = PlayerPrefs.GetInt("SelectedGender", 0);

        // Exibe o valor de selectedGender no console
        Debug.Log("Selected Gender: " + (selectedGender == 0 ? "Feminino" : "Masculino"));


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CharacterList.Instance.SelectedCharIndex++;
            UpdateCharacterPanels();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CharacterList.Instance.SelectedCharIndex--;
            UpdateCharacterPanels();
        }
    }

    private void UpdateCharacterPanels()
    {
        characterPanelLeft.UpdateCharacterPanel(CharacterList.Instance.GetPrevious());
        characterPanelRight.UpdateCharacterPanel(CharacterList.Instance.GetNext());
    }

}
