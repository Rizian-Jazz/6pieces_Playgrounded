using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int currentLevel = 1, currentXP = 0, xpToNextLevel = 100, XPValue;
    public XPBar XPBar;
    public GameObject XPOrbPrefab;
    
    void Start()
    {
        XPBar.SetMaxXP(xpToNextLevel);
        XPBar.SetXP(currentXP);
    }
    
    public void LevelUp(int XPValue)
    {
        currentXP += XPValue;
        if (currentXP >= xpToNextLevel)
        {
            currentLevel++;
            currentXP = 0;
            xpToNextLevel = Mathf.CeilToInt(xpToNextLevel * 1.02f);
        }
        XPBar.SetXP(currentXP);
        Debug.Log("Player Level: " + currentLevel);
    }
}
