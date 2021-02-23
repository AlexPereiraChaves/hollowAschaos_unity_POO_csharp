using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate : MonoBehaviour
{
    public GameObject enemy;
    public int Xpos;
    public int Zpos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop()); 
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    IEnumerator EnemyDrop()
    {
        while ( enemyCount < 10)
        {
            Xpos = Random.Range(6, 21);
            Zpos = Random.Range(3, 27);
            Instantiate(enemy, new Vector3(Xpos, 0.2f, Zpos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
