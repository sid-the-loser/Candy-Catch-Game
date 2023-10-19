using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static float[] boundaries = new float[2] { -6.66f, 6.66f }; 
    [SerializeField] int speed = 20;

    [SerializeField] int score;

    float candyTimer = 0;

    Text scoreboard;
    GameObject resetButton;

    Vector3 move_dir;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this);
        CandySpawning.Init();
        scoreboard = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<Text>();
        resetButton = GameObject.FindGameObjectWithTag("Reset");
        resetButton.SetActive(false);
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

        if (CandySpawning.spawnCounter >= 15)
        {
            scoreboard.text = $"Game Ended!, Score: {score}\n";
            if (score > 20)
            {
                scoreboard.text += "Candy Craze!!";
            }
            else if (score > 10)
            {
                scoreboard.text += "Halloween!!";
            }
            else if (score > 6)
            {
                scoreboard.text += "Sugar rush!!";
            }
            else
            {
                scoreboard.text += "Sadness!!";
            }

            resetButton.SetActive(true);
        }
        else
        {
            scoreboard.text = $"Score: {score}";
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

    public void ResetScene()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);    
    }

}
