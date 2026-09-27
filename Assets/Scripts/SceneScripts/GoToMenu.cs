using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToMenu : MonoBehaviour
{
    public void GoToMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
