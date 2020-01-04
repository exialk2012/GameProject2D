using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        public static bool isGame;
        const int blockCount = 6;
        [Header("地块组")]
        public List<GameObject> blockList;
        GameObject player;
        // Start is called before the first frame update
        void Start()
        {
            isGame = true;
            player = GameObject.Find("Player");
            StartCoroutine(InitBlock());
        }

        private void Update()
        {
            if (player.GetComponent<Rigidbody2D>().position.y<-5.2f)
            {
                isGame = false;
                player.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
        }

        // Update is called once per frame
        IEnumerator InitBlock()
        {
            if (isGame)
            {
                for (int i = 0; i < blockCount; i++)
                {
                    var seed = UnityEngine.Random.Range(0, blockList.Count);
                    var randomX = UnityEngine.Random.Range(-1.39f, 1.39f);
                    GameObject.Instantiate(blockList[seed], new Vector3(randomX, -5.2f, blockList[seed].transform.position.z), Quaternion.identity, gameObject.transform);
                    yield return new WaitForSeconds(3f);
                }
            }
            
        }
    }
}