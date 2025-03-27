using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject maleCharacterPrefab;
    public GameObject femaleCharacterPrefab;

    private static GameObject selectedCharacter;

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
        SceneManager.LoadScene("MainTestScene");
    }

    public static GameObject GetSelectedCharacter(){
        return selectedCharacter;
    }
}
