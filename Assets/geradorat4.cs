using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geradorat4 : MonoBehaviour
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
        while (enemyCount < 5)
        {
            Xpos = Random.Range(-148, -159);
            Zpos = Random.Range(15, 9);
            Instantiate(enemy, new Vector3(Xpos, 0.2f, Zpos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
