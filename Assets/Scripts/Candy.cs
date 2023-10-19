using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Candy : MonoBehaviour
{

    [SerializeField] int score;
    [SerializeField] int speed = 5;

    Vector3 mov_dir = new Vector3 (0, -1, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += mov_dir * speed * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().AddScore(score);
            CandySpawning.DisableCandy(gameObject);
        }
        else
        {
            Debug.Log("What?");
        }
    }
}
