using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
    

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    [SerializeField] private Slider playerHealthSlider;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Slider playerExpSlider;
    [SerializeField] private TMP_Text ExpText;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    [SerializeField] public TMP_Text timerText;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }

    public void UpdateHealthSlider(){
        playerHealthSlider.maxValue= PlayerController.Instance.playerMaxHealth;
        playerHealthSlider.value= PlayerController.Instance.playerHealth;
        healthText.text = playerHealthSlider.value + "/ " + playerHealthSlider.maxValue;
    }
    
    public void UpdateExpSlider(){
        playerExpSlider.maxValue= PlayerController.Instance.playerLevels[PlayerController.Instance.currentLevel-1];
        playerExpSlider.value= PlayerController.Instance.experiencePoints;
        ExpText.text = playerExpSlider.value + "/ " + playerExpSlider.maxValue;
    }


    public void UpdateTimer(float timer)
    {
        float min = Mathf.FloorToInt(timer / 60f);
        float sec = Mathf.FloorToInt(timer % 60f);

        timerText.text = min + ":" + sec.ToString("00");
    }


}
