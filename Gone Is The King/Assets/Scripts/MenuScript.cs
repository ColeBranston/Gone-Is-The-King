using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject maleCharacterPrefab;
    public GameObject femaleCharacterPrefab;

    private static GameObject selectedCharacter;

    void Start()
    {
        // Force windowed mode with desired resolution
        // Screen.fullScreen = false;
        // Screen.SetResolution(854, 480, false);
    }

    public void PlayGame(){
        SceneManager.LoadSceneAsync(1);
    }

    public void CloseGame(){
        Application.Quit();
    }

    public void SelectMale()
    {
        selectedCharacter = maleCharacterPrefab;
        LoadGameScene();
    }

    public void SelectFemale()
    {
        selectedCharacter = femaleCharacterPrefab;
        LoadGameScene();
    }
    
    private void LoadGameScene(){
        DontDestroyOnLoad(selectedCharacter);
        SceneManager.LoadScene(2);
    }

    public static GameObject GetSelectedCharacter(){
        return selectedCharacter;
    }
}
