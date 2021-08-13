using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TargetFound : MonoBehaviour
{
    public GameData gameData;
    public float animationTime = 2f, speed;

    Sprite targetImage;
    Vector3 targetPos, scaleStep;

    // Start is called before the first frame update
    void Start()
    {
        targetImage = gameData.targetSprite;
        GetComponentInChildren<Image>().sprite = targetImage;

        scaleStep = Vector3.one;

        Transform target = GameObject.FindGameObjectWithTag("Target").transform;
        targetPos = target.position;

        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        float startingTime = Time.time;

        while(Time.time - startingTime <= animationTime)
        {
            Vector3 diff = (transform.position - targetPos).normalized * Time.deltaTime * speed;

            transform.position -= diff;

            if (Time.time - startingTime <= 1f)
            {
                transform.localScale += scaleStep * Time.deltaTime;
            }
            else
            {
                transform.localScale -= scaleStep * Time.deltaTime;
            }

            if (Mathf.Abs(transform.position.x - targetPos.x) <= 20f && transform.position.y - targetPos.y <= 20f)
            {
                Destroy(gameObject);
            }

            yield return null;
        }

        Destroy(gameObject);
    }
}
