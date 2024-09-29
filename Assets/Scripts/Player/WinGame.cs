using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    public static WinGame Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void Win()
    {
        winPanel.SetActive(true);
        SceneManager.Instance.Player.IsWon = true;
    }
}
