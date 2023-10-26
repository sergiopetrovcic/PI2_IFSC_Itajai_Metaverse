using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject femininoCharacterPrefab;
    public GameObject masculinoCharacterPrefab;

    private GameObject target;

    private void Start()
    {
        // Determine qual personagem seguir com base na escolha do jogador
     
        int selectedGender = PlayerPrefs.GetInt("SelectedGender", 0);

        if (selectedGender == 0)
        {
            target = femininoCharacterPrefab;
        }
        else
        {
            target = masculinoCharacterPrefab;
        }
    }
}
