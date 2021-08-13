using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIM_TakeDamage : MonoBehaviour
{
    public GM_Events gm_Events;
    public Image fillImage;
    public GameObject damageAmount;
    public Text currentHealthText, totalHealthText;
    public Animator _animator; 

    public GameData gameData;

    float health, totalStamina;
    string DamageAnimationTrigger = "damage";

    private void OnEnable()
    {
        gm_Events.EventTakeDamage += OnTakeDamage;

        health = totalStamina = gameData.stamina;

        currentHealthText.text = health.ToString();
        totalHealthText.text = totalStamina.ToString();
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

        _animator.SetTrigger(DamageAnimationTrigger);
        InstantiateDamageAmount(damage, pos);   
        StartCoroutine(ChangeHealthBar());
        Invoke("ChangeNumbers", 0.5f);
    }

    void ChangeNumbers()
    {
        currentHealthText.text = health.ToString();
        totalHealthText.text = totalStamina.ToString();
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
