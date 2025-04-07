using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadSceneAsync(1);
    }

    public void CloseGame(){
        Application.Quit();
    }
}
