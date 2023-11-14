using UnityEngine;

public class AtivarPersonagem : MonoBehaviour
{
    public GameObject femininoCharacterPrefab;
    public GameObject masculinoCharacterPrefab; 

    private void Awake()
    {
        // Verifique o valor de SelectedGender nas PlayerPrefs
        int selectedGender = PlayerPrefs.GetInt("SelectedGender", 0);

        // Ative o personagem correspondente com base no valor de SelectedGender
        if (selectedGender == 0)
        {
            femininoCharacterPrefab.SetActive(false);
            masculinoCharacterPrefab.SetActive(true);
        }
        else
        {
            femininoCharacterPrefab.SetActive(true);
            masculinoCharacterPrefab.SetActive(false);
        }
    }
}
