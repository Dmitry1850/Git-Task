using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitAndRestartScript : MonoBehaviour
{
    public void OnClickExitButton() => Application.Quit();
    public void OnClickRestartButton() => SceneManager.LoadScene(0);
}
