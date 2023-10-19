using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandySpawning
{
    static GameObject[] candyObj;

    public static int spawnCounter;

    public static void Init()
    {
        spawnCounter = 0;
        candyObj = GameObject.FindGameObjectsWithTag("Candy");
        foreach (GameObject item in candyObj)
        {
            item.SetActive(false);
        }
    }

    public static void Spawn()
    {
        if (spawnCounter < 15)
        {
            for (int j = 0; j < candyObj.Length; j++)
            {
                candyObj[j].SetActive(false);
            }
            var i = Random.Range(0, candyObj.Length);

            candyObj[i].SetActive(true);

            candyObj[i].GetComponent<Transform>().position = new Vector3(Random.Range(Player.boundaries[0], Player.boundaries[1]), 8, 0);

            spawnCounter++;
        }
    }

    public static void DisableCandy(GameObject candy)
    {
        candy.SetActive(false);
    }

}
