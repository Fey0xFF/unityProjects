using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilBlock : MonoBehaviour
{
    [SerializeField] Paddle paddle;

    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
        playerPos.x = paddle.transform.position.x;
        transform.position = playerPos;

        //playerPos.x = Mathf.Clamp(paddle.transform.position.x);
        //transform.position = paddle.transform.position.x;
    }
}


//Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
//paddlePos.x = Mathf.Clamp(GetXPos(), paddleXMin, paddleXMax);
//        transform.position = paddlePos;