using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;
    public List<GameObject> powerUpTemplateList;
    public int spawnInterval;
    private float timer, timerForDuration;
    public int duration;

    private List<GameObject> powerUpList;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
        timerForDuration = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        timerForDuration = Time.deltaTime;
        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }
        if(powerUpList.Count == maxPowerUpAmount)
        {
            if (timerForDuration > duration)
            {
                RemovePowerUp(powerUpList[0]);
                timerForDuration = 0;
            }
        } else
        {
            timerForDuration = 0;
        }
        
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }


    public void GenerateRandomPowerUp(Vector2 position)
    {
        Debug.Log("Spawned");

        if (powerUpList.Count >= maxPowerUpAmount)
        {
            RemovePowerUp(powerUpList[0]);
            return;
        }

        if (position.x < powerUpAreaMin.x ||
            position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y ||
            position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, 1), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
}
