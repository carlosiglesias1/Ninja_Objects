using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    private GameManager gameManager;
    public int pointValue;
    Vector3 RandomForce(float minSpeed, float maxSpeed)
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque(float minTorque, float maxTorque)
    {
        return Random.Range(minTorque, maxTorque);
    }
    Vector3 RandomSpawnPosX(float minXRange, float maxXRange, float spawnY)
    {
        return new Vector3(Random.Range(minXRange, maxXRange), spawnY);
    }
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(minSpeed, maxSpeed), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(-maxTorque, maxTorque),
        RandomTorque(-maxTorque, maxTorque),
        RandomTorque(-maxTorque, maxTorque), ForceMode.Impulse);
        transform.position = RandomSpawnPosX(-xRange, xRange, ySpawnPos);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        //Si soy un objeto bueno que ha colisionado con el sensor,
        // se acaba la partida
        if (!gameObject.CompareTag("Bad") && other.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
    private void OnMouseDown()
    {
        if (!gameManager.isGameOver())
        {

            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
    }
}
