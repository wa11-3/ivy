using System.Collections;
using UnityEngine;
using TMPro;

public class Environment : MonoBehaviour
{
    public GameObject[] players;
    public GameObject[] enemies;
    public int typeEnemy;
    public float timeSpawn;

    public SpriteRenderer foreItem;
    public SpriteRenderer middleItem;
    public SpriteRenderer backItem;

    public Vector3 startPos;

    public TextMeshProUGUI score;

    public float enviVelocity;
    public float middleFactor;
    public float backFactor;

    private GameObject player;

    private void Start()
    {
        Instantiate(players[Manager.numberCharac]);
        StartCoroutine(InstatiateEnemies());
    }

    private void Update()
    {
        ManageGround();
        IncreaseVelocity();
    }

    void ManageGround()
    {
        foreItem.size = new Vector2(foreItem.size.x + Manager.enviVelocity, foreItem.size.y);
        middleItem.size = new Vector2(middleItem.size.x + (Manager.enviVelocity * middleFactor), middleItem.size.y);
        backItem.size = new Vector2(backItem.size.x + (Manager.enviVelocity * middleFactor), backItem.size.y);
    }

    void IncreaseVelocity()
    {
        Manager.enviVelocity += (Time.deltaTime * 0.00001f);
        Manager.score += Time.deltaTime;
        score.text = "Score: " + Manager.score.ToString("f0");
        print(Manager.score);
    }

    IEnumerator InstatiateEnemies()
    {
        while (true)
        {
            typeEnemy = (int)Random.Range(0, enemies.Length);
            switch (typeEnemy)
            {
                case 0:
                    Instantiate(enemies[0], startPos, gameObject.transform.rotation);
                    break;

                case 1:
                    Instantiate(enemies[1], startPos + new Vector3(Random.Range(-10, 2), Random.Range(1, 8), 0), gameObject.transform.rotation);
                    break;

                case 2:
                    break;
            }

            timeSpawn = Random.Range(2.0f, 5.0f);
            yield return new WaitForSeconds(timeSpawn);
        }
    }
}
