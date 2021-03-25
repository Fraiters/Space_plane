using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEmitter : MonoBehaviour
{
    public Transform enemies;
    public float minDelay, maxDelay; // задержка между запусками
    private float nextLaunchTime; // время следующего запуска

    // Update is called once per frame
    private void Update()
    {
        if (GameControllerScript.instance.isStarted == false)
        {
            return;
        }

        if (Time.time > nextLaunchTime)
        {
            float posY = 0;
            float posX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2); // задаем случайное положение врага по оси X
            float posZ = transform.position.z;

            Instantiate(enemies.transform.GetChild(0), new Vector3(posX, posY, posZ), Quaternion.Euler(0, 180,0)); // создаем врага
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay); // меняем время следующего появления врага
        }
    }
}
