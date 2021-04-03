using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public TextMesh textMesh;

    public void SetNumber(int amount)
    {
        textMesh.text = "-" + amount;
    }

    public void DestroyDamage()
    {
        Destroy(gameObject);
    }
}
