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
            // PlayerPrefs���� �ְ� ���� ��������
            int highScore = PlayerPrefs.GetInt("HighWaveScore", 0);
           

            // �ؽ�Ʈ ����
            highScoreText.text = "HighWaveScore:" + highScore;
           

            // �ؽ�Ʈ ������ ���η� ���ڷ� ��ħ
            highScoreText.alignment = TextAlignmentOptions.Center;
           

            // �����̽��� �˸� UI ����
            if (interactionUI != null)
                interactionUI.SetActive(false);

            // ���� �г� ���̱�
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
