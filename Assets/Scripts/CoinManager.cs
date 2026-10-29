using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public TMP_Text obtainableText;

    public int coins = 0;
    public int targetCoins = 20;
 
    public GameObject LevelCompleteUI;

    void Start()
    {
        obtainableText.text = "Coins : 0";
        LevelCompleteUI.SetActive(false);
    }

    public void AddCoin()
    {
        coins++;
        obtainableText.text = "Coins : " + coins;

        Debug.Log("TOTAL COINS = " + coins);

        if (coins >= targetCoins)
        {

            Win();
        }
    }

    void Win()
    {
        LevelCompleteUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}