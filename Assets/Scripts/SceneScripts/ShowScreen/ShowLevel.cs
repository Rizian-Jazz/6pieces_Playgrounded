using UnityEngine;
using TMPro;
public class ShowLevel : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    PlayerLevel playerLevel;
    void Start()
    {
        playerLevel = FindFirstObjectByType<PlayerLevel>();
    }

    void Update()
    {
        levelText.text = "Level: " + playerLevel.currentLevel.ToString();
    }
}
