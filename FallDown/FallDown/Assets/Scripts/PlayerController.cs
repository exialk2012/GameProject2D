using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        Rigidbody2D playerRB;
        [Header("角色属性相关")]
        public float moveSpeed = 8f;
        float moveX;
        // Start is called before the first frame update
        void Start()
        {
            playerRB = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            moveX = Input.GetAxisRaw("Horizontal");
        }

        private void FixedUpdate()
        {
            if (GameController.isGame)
            {
                PlayerMovement();
            }
            
        }

        private void PlayerMovement()
        {
            playerRB.MovePosition(new Vector2(playerRB.position.x + moveX * moveSpeed * Time.deltaTime,playerRB.position.y));
            if (moveX>0)
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Player/PlayerRight");
            }
            else if (moveX<0)
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Player/PlayerLeft");
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Player/PlayerIdle");
            }
        }
    }
}