using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIM_TakeDamage : MonoBehaviour
{
    public GM_Events gm_Events;
    public Image fillImage;
    public GameObject damageAmount;

    public GameData gameData;

    float health, totalStamina;

    private void OnEnable()
    {
        gm_Events.EventTakeDamage += OnTakeDamage;

        health = totalStamina = gameData.stamina;
    }

    private void OnDisable()
    {
        gm_Events.EventTakeDamage -= OnTakeDamage;
    }
    
    public void OnTakeDamage(int damage, Vector3 pos)
    {
        health -= damage;
        TestSaveManager.instance.testSave.staminaUsed = totalStamina - health;

        if (health <= 0f)
        {
            health = 0f;
            gm_Events.CallEventGameOver();
        }

        InstantiateDamageAmount(damage, pos);   
        StartCoroutine(ChangeHealthBar());
    }
 
    void InstantiateDamageAmount(int amount, Vector3 pos)
    {
        Damage damage = Instantiate(damageAmount, pos, Quaternion.identity).GetComponent<Damage>();
        damage.SetNumber(amount);
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
