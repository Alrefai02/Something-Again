using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject EnemyPre;
    public GameObject EnemyDeath;

    public Transform left;
    public Transform right;

    int score = 0;
    public TMP_Text scoreText;
    public TMP_Text scoreTextPanel;

    Coroutine coroutine;

    public Player player;

    public GameObject LossPanel;
    





    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemyLeft", 0f, 1f);
        InvokeRepeating("SpawnEnemyLeft", 10f, 4f);
        InvokeRepeating("SpawnEnemyLeft", 20f, 4f);        
        
        InvokeRepeating("SpawnEnemyRight", 0f, 1f);
        InvokeRepeating("SpawnEnemyRight", 10f, 4f);
        InvokeRepeating("SpawnEnemyRight", 20f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !player.lost)
        { 
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    if (coroutine != null)
                        StopCoroutine(coroutine);

                    hit.collider.gameObject.GetComponent<ParticleSystem>().Play();
                    hit.collider.gameObject.GetComponent<Collider2D>().enabled = false;
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().enabled = false;

                    score++;
                    scoreText.text = score + "";
                    coroutine = StartCoroutine("TextAnim");
                    Destroy(hit.collider.gameObject, 1f);

                }
            }
        }

        if (player.lost)
        {
            LossPanel.SetActive(true);
            scoreText.text = "";
            scoreTextPanel.text = score + "";
            CancelInvoke();
        }
    }

    void SpawnEnemyLeft()
    {
        float spawnX = left.position.x + Random.Range(-4f, 4f);
        float spawnY = left.position.y + Random.Range(-4f, 4f);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        Instantiate(EnemyPre, spawnPosition, Quaternion.identity);
    }

    void SpawnEnemyRight()
    {
        float spawnX = right.position.x + Random.Range(-4f, 4f);
        float spawnY = right.position.y + Random.Range(-4f, 4f);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        Instantiate(EnemyPre, spawnPosition, Quaternion.identity);
    }

    IEnumerator TextAnim()
    {
        for (float i=1f; i <= 1.2f; i+=0.05f)
        {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        scoreText.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

        for (float i = 1.2f; i >= 1f; i -= 0.05f)
        {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        scoreText.rectTransform.localScale = new Vector3(1, 1, 1);    
    }

    public void GoToScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
