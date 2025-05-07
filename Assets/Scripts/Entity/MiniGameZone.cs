using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameZone : MonoBehaviour
{
    [SerializeField] private string SampleScene = "SampleScene";
    [SerializeField] private GameObject MinigameTextUI;
    private bool isPlayerInRange = false;
    private void Start()
    {
        if (MinigameTextUI != null)
            MinigameTextUI.SetActive(false);
    }
    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SampleScene);
        }
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            isPlayerInRange = true;
            if (MinigameTextUI != null)
                MinigameTextUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (MinigameTextUI != null)
                MinigameTextUI.SetActive(false);
        }
    }
}
