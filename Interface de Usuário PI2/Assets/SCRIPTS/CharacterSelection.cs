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
        bool isLeftPanelVisible = characterPanelLeft.gameObject.activeSelf;

        if (isLeftPanelVisible)
        {
            Instantiate(femininoCharacterPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Instantiate(masculinoCharacterPrefab, spawnPoint.position, Quaternion.identity);
        }

        int selectedGender = CharacterList.Instance.SelectedCharIndex;
        Debug.Log("SelectedGender: " + selectedGender);

        GameObject[] personagens = new GameObject[2];
        personagens[0] = femininoCharacterPrefab;
        personagens[1] = masculinoCharacterPrefab;

        if (selectedGender >= 0 && selectedGender < personagens.Length)
        {
            GameObject character = Instantiate(personagens[selectedGender], transform.position, Quaternion.identity);

            DontDestroyOnLoad(character);
        }
        else
        {
            Debug.LogError("Índice de gênero selecionado fora dos limites.");
        }

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
    }
}
