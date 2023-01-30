using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBattle : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}

