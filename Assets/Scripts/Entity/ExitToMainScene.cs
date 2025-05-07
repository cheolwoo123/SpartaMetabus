using UnityEngine;
using UnityEngine.SceneManagement;



public class ExitToMainScene : MonoBehaviour
{
    public void ExitToMain()
    {
       
        SceneManager.LoadScene("WaitRoom");
    }
}
