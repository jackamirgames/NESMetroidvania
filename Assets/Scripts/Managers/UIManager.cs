using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    [Header("Canvases")]
    [SerializeField] private Canvas gameplayCanvas;

    [Header("Text")]
    [SerializeField] private TMP_Text healthText;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than 1 UI Manager. FIX IT NOW");
        }
        instance = this;
    }

    public void UpdateHealthText(int currentHealth)
    {
        healthText.text = "Health: " + currentHealth;
    }
}
