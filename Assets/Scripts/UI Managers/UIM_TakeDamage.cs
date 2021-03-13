using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIM_TakeDamage : MonoBehaviour
{
    public GM_Events GM_Events;
    public Image fillImage;

    public GameData gameData;

    float health, totalStamina;

    private void OnEnable()
    {
        GM_Events.EventTakeDamage += OnTakeDamage;

        health = totalStamina = gameData.stamina;
    }

    private void OnDisable()
    {
        GM_Events.EventTakeDamage -= OnTakeDamage;
    }

    public void OnTakeDamage(int damage)
    {
        health -= damage;
        TestSaveManager.instance.testSave.staminaUsed = totalStamina - health;

        if (health <= 0f)
        {
            health = 0f;
            GM_Events.CallEventGameOver();
        }
        StartCoroutine(ChangeHealthBar());
    }

    IEnumerator ChangeHealthBar()
    {
        for (int i = 1; i <= 10; i++)
        {
            fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, health / totalStamina, (float)i / 10f);
            yield return null;
        }
    }
}
