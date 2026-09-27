using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class DeathScene : MonoBehaviour
{
    public float fadeDuration = 1f;
    private Image fadeImage;
    PlayerHealth playerHealth = FindFirstObjectByType<PlayerHealth>();

    void Start()
    {
        GameObject canvas = new GameObject("FadeCanvas");
        Canvas c = canvas.AddComponent<Canvas>();
        c.renderMode = RenderMode.ScreenSpaceOverlay;
        c.sortingOrder = 999;

        GameObject panel = new GameObject("FadePanel");
        panel.transform.SetParent(canvas.transform);
        fadeImage = panel.AddComponent<Image>();
        fadeImage.color = new Color(0, 0, 0, 0);

        RectTransform rt = panel.GetComponent<RectTransform>();
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;
    }
    public void FixedUpdate()
    {
        if(playerHealth != null && playerHealth.currentHealth <= 0)
        {
            StartCoroutine(FadeAndLoad());
        }
    }
    IEnumerator FadeAndLoad()
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, elapsed / fadeDuration);
            yield return null;
        }
        SceneManager.LoadScene("Death Screen");
    }
}
