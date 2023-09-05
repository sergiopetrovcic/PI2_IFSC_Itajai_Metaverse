using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] CharacterPanel characterPanelLeft;

    [SerializeField] CharacterPanel characterPanelRight;
    void Start()
    {
        CharacterList.Instance.SelectedCharIndex = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            CharacterList.Instance.SelectedCharIndex++;
            Debug.Log("left");
            UpdatCharacterPanels();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            CharacterList.Instance.SelectedCharIndex--;
            Debug.Log("right");
            UpdatCharacterPanels();
        }
    }

    private void UpdatCharacterPanels() 
    {
        characterPanelLeft.UpdateCharacterPanel(CharacterList.Instance.GetPrevious());
        characterPanelRight.UpdateCharacterPanel(CharacterList.Instance.GetNext());

    }
}
