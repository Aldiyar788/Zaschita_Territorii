using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // убедитесь, что панель Game Over скрыта в начале игры
        gameOverPanel.SetActive(false);
    }

    
    public void ShowGameOverPanel()
    {
        // Перезапустить текущую сцену
        gameOverPanel.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
