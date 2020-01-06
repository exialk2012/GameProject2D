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
        private int speedUpBlockCount;
        public static int currentBlockCount = 0;
        public static int speedLevel;
        [Header("地块属性设置")]
        public static float blockUpSpeed = 1f;
        // Start is called before the first frame update
        void Start()
        {
            blockRB = GetComponent<Rigidbody2D>();
            speedUpBlockCount = 10;
            print($"现在的速度是{blockUpSpeed}");
        }

        // Update is called once per frame
        void Update()
        {
            if (GameController.isGame)
            {
                BlockUp();
            }

            if (currentBlockCount> speedUpBlockCount)
            {
                speedLevel += 1;
                currentBlockCount = 0;
            }
            
        }

        private void BlockUp()
        {
            blockRB.MovePosition(new Vector2(blockRB.position.x, blockRB.position.y + (blockUpSpeed*(1+speedLevel*0.5f)) * Time.deltaTime));
            if (blockRB.position.y>5.2f)
            {
                GameObject.DestroyImmediate(gameObject);
                GameController.blockCount -= 1;
                BlockController.currentBlockCount += 1;
            }
        }
    }
}