using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerador4: MonoBehaviour
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
            Xpos = Random.Range(-159, -148);
            Zpos = Random.Range(5, 14);
            Instantiate(enemy, new Vector3(Xpos, 0.2f, Zpos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
