using UnityEngine;

public class LostGame : MonoBehaviour
{
    [SerializeField] private GameObject lostPanel;
    public static LostGame Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void Lost()
    {
        lostPanel.SetActive(true);
    }
}
