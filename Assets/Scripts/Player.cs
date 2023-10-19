using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float[] boundaries = new float[2]; 
    [SerializeField] int speed = 10;

    Vector3 move_dir;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += move_dir * speed * Time.deltaTime;

        if (boundaries[0] > transform.position.x)
        {
            transform.position = new Vector3(boundaries[0], transform.position.y, transform.position.z);
        }
        else if (boundaries[1] < transform.position.x)
        {
            transform.position = new Vector3(boundaries[1], transform.position.y, transform.position.z);
        }
    }

    public void SetMovementDir(Vector2 direction)
    {
        move_dir.x = direction.x;
    }
}
