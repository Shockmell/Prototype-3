using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30.0f;
    private PlayerController script;
    private float leftBound = -15.0f;

    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!script.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if(transform.position.x < leftBound && gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
