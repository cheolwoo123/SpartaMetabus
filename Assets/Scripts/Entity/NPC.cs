using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private GameObject interactionUI;
    [SerializeField] private GameObject scorePanel;

    private bool isPlayerInRange = false;

    private void Start()
    {
        interactionUI?.SetActive(false);
        scorePanel?.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            // PlayerPrefs에서 최고 점수 가져오기
            int highScore = PlayerPrefs.GetInt("HighWaveScore", 0);
           

            // 텍스트 설정
            highScoreText.text = "HighWaveScore:" + highScore;
           

            // 텍스트 정렬을 가로로 일자로 펼침
            highScoreText.alignment = TextAlignmentOptions.Center;
           

            // 스페이스바 알림 UI 숨김
            if (interactionUI != null)
                interactionUI.SetActive(false);

            // 점수 패널 보이기
            if (scorePanel != null)
                scorePanel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactionUI?.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;

            if (interactionUI != null)
                interactionUI.SetActive(false);

            if (scorePanel != null)
                scorePanel.SetActive(false);
        }
    }
}
