using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame(string SceneMain)
    {
        SceneManager.LoadScene(SceneMain);
    }
}
