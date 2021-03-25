using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float tilt; // наклон корабля
    private Rigidbody ship;
    private float moveHorizontal; // переменная для движения по горизонтали
    private float moveVertical; // переменная для движения по вертикали
    private float xMinBorder = -27; // левая граница поля
    private float xMaxBorder = 24; // правая граница поля 
    private float zMinBorder = -53; // нижняя граница поля
    private float zMaxBorder = 24; // верхняя граница поля
    private float clampedPositionX; // ограничение поля по горизонтали
    private float clampedPositionZ; // ограничение поля по вертикали
    public GameObject lazerShot; // объект лазер
    public Transform lazerGun; // позиция главной пушки
    public GameObject sideLeftLazerShot; // объект левый боковой лазер
    public Transform sideLeftLazerGun; // позиция левой пушки
    public GameObject sideRightLazerShot; // объект правый боковой лазер
    public Transform sideRightLazerGun; // позиция правой пушки
    private float nextShotTime; // время следующего выстрела
    public float shotDelay; // задержка между выстрелами главной пушки
    public float sideShotDelay; // задержка между выстрелами боковой пушки
    // Start is called before the first frame update
    private void Start()
    {
        ship = GetComponent<Rigidbody>(); // получение компонента Rigidbody
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameControllerScript.instance.isStarted == false)
        {
            return;
        }

        moveHorizontal = Input.GetAxis("Horizontal"); // движение по горизонтали
        moveVertical = Input.GetAxis("Vertical"); // движение по вертикали

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed; // придаем скорость Старфаеру

        clampedPositionZ = Mathf.Clamp(ship.position.z, zMinBorder, zMaxBorder); // ограничение поля по оси z
        clampedPositionX = Mathf.Clamp(ship.position.x, xMinBorder, xMaxBorder); // ограничение поля по оси x

        ship.position = new Vector3(clampedPositionX, 0, clampedPositionZ); 

        ship.rotation = Quaternion.Euler(moveVertical * tilt, 0, -moveHorizontal * tilt); // задаем поворот кораблю

        if (Input.GetButton("Fire1") && Time.time > nextShotTime)
        {
            Instantiate(lazerShot, lazerGun.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }

        if (Input.GetButton("Fire2") && Time.time > nextShotTime)
        {
            Instantiate(sideLeftLazerShot, sideLeftLazerGun.position, Quaternion.identity);
            Instantiate(sideRightLazerShot, sideRightLazerGun.position, Quaternion.identity);
            nextShotTime = Time.time + sideShotDelay;
        }
    }
}
