using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float[] boundaries = new float[2] { -6.66f, 6.66f }; 
    [SerializeField] int speed = 10;

    int score;

    float candyTimer = 0;

    Vector3 move_dir;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this);
        CandySpawning.Init();
    }

    // Update is called once per frame
    void Update()
    {
        candyTimer += Time.deltaTime;

        transform.position += move_dir * speed * Time.deltaTime;

        if (boundaries[0] > transform.position.x)
        {
            transform.position = new Vector3(boundaries[0], transform.position.y, transform.position.z);
        }
        else if (boundaries[1] < transform.position.x)
        {
            transform.position = new Vector3(boundaries[1], transform.position.y, transform.position.z);
        }

        if (candyTimer >= 3)
        {
            candyTimer = 0;
            CandySpawning.Spawn();
        }
    }

    public void SetMovementDir(Vector2 direction)
    {
        move_dir.x = direction.x;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
