using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemy;
    public float speed;
    public GameObject explosionPlayer; // взрыв корабля
    public GameObject lazerShot;
    public Transform lazerGun;
    private float nextShotTime; // время следующего выстрела
    public float shotDelay; // задержка между выстрелами 


    // Start is called before the first frame update
    private void Start()
    {
        enemy = GetComponent<Rigidbody>();
        enemy.velocity = new Vector3(0, 0, -speed);
    }

    // вызывается при столкновении с другим объектом (переменная other)
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyLazerShot" || other.tag == "GameBoundary")
        {
            return;
        }

        Destroy(gameObject); // уничтожаем вражеский корабль
        Destroy(other.gameObject); // уничтожаем объект, с которым сталкивается вражеский корабль

        Instantiate(explosionPlayer, transform.position, Quaternion.identity); // добавляем взрыв вражеского корабля

        if (other.tag == "Player")
        {
            Instantiate(explosionPlayer, other.transform.position, Quaternion.identity); // добавляем взрыв корабля при столкновении с вражеским
        }

        if (other.tag == "SideLeftLazerShot" || other.tag == "SideRightLazerShot" || other.tag == "LazerShot")
        {
            GameControllerScript.instance.score += 5;// увеличение кол-во очков за попадание
        }
    }

    private void Update()
    {
        if (Time.time > nextShotTime)
        {
            Instantiate(lazerShot, lazerGun.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }
    }
}
