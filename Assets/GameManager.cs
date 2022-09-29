using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EnemyPre;

    public Transform left;
    public Transform right;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 0.7f);
        InvokeRepeating("SpawnEnemy", 6f, 0.7f);
        InvokeRepeating("SpawnEnemy", 10f, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider.gameObject.tag == "Enemy")
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }

    void SpawnEnemy()
    {
        float spawnX = Random.Range(left.position.x, right.position.x);
        float spawnY = Random.Range(left.position.y, right.position.y);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        Instantiate(EnemyPre, spawnPosition, Quaternion.identity);
    }
}
