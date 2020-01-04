using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

namespace Assets.Scripts
{
    public class BlockController : MonoBehaviour
    {
        Rigidbody2D blockRB;
        [Header("地块属性设置")]
        public float blockUpSpeed = 3f;
        // Start is called before the first frame update
        void Start()
        {
            blockRB = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GameController.isGame)
            {
                BlockUp();
            }
            
        }

        private void BlockUp()
        {
            blockRB.MovePosition(new Vector2(blockRB.position.x, blockRB.position.y + blockUpSpeed * Time.deltaTime));
            if (blockRB.position.y>5.2f)
            {
                blockRB.MovePosition(new Vector2(blockRB.position.x,-5.6f));
            }
        }
    }
}