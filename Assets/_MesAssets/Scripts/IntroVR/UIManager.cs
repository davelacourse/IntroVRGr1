using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void SceneIntro()
    {
        SceneManager.LoadScene("IntroVR");
    }
}
