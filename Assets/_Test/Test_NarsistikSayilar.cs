using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_NarsistikSayilar : MonoBehaviour
{
    int number = 1, bekleme = 0;
    List<int> narsistikList;

    // Start is called before the first frame update
    void Start()
    {
        narsistikList = new List<int>();
        StartCoroutine(FindNarsistik());
    }

    IEnumerator FindNarsistik()
    {
        int narsistikCount = 0;

        while (number < 1000000)
        {
            int digitCount = 0;

            if (number < 10)
            {
                digitCount = 1;
            }
            else if (number < 100)
            {
                digitCount = 2;
            }
            else if (number < 1000)
            {
                digitCount = 3;
            }
            else if (number < 10000)
            {
                digitCount = 4;
            }
            else if (number < 100000)
            {
                digitCount = 5;
            }
            else if (number < 1000000)
            {
                digitCount = 6;
            }

            int narsistik = 0;
            int tempNumber = number;

            for (int i = 0; i < digitCount; i++)
            {
                narsistik += (int)Mathf.Pow((float)(tempNumber % 10), (float)digitCount);
                tempNumber /= 10;
            }

            if (number == narsistik)
            {
                narsistikList.Add(number);
            }

            bekleme++;
            number++;

            if(bekleme == 10000)
            {
                bekleme = 0;
                Debug.Log(number);
                yield return null;
            }
        }

        foreach (int n in narsistikList)
        {
            Debug.Log("Narsistik " + n);
        }

        Debug.Log("Toplam Narsistik Sayı: " + narsistikList.Count);
    }
}
