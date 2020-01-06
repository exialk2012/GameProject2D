using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        public static bool isGame;
        public static int blockCount;
        private float blockTimer;
        [Header("地块组")]
        public List<GameObject> blockList;
        GameObject player;
        // Start is called before the first frame update
        void Start()
        {
            isGame = true;
            player = GameObject.Find("Player");
            blockCount = 0;
            blockTimer = Random.Range(3f, 5f);
            StartCoroutine(InitBlock());

        }

        private void Update()
        {
            blockTimer -= Time.deltaTime;
            if (player.GetComponent<Rigidbody2D>().position.y<-5.2f)
            {
                isGame = false;
                player.GetComponent<Rigidbody2D>().gravityScale = 0;
            }

            if (blockCount<7)
            {
                if (blockTimer<0)
                {
                    CreatBlock();
                    blockTimer = UnityEngine.Random.Range(3f,5f);
                }
                
            }

        }

        // Update is called once per frame
        IEnumerator InitBlock()
        {
            
            CreatBlock();
            yield return new WaitForSeconds(UnityEngine.Random.Range(3f,5f));
        }

        private void CreatBlock()
        {
            if (isGame)
            {
                var seed = UnityEngine.Random.Range(0, blockList.Count);
                var randomX = UnityEngine.Random.Range(-1.39f, 1.39f);
                GameObject.Instantiate(blockList[seed], new Vector3(randomX, -5.2f, blockList[seed].transform.position.z), Quaternion.identity, gameObject.transform);
                blockCount += 1;
            }
        }

    }
}