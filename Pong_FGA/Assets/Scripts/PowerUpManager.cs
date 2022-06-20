using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{

    public int maxPowerUpAmount;
    public int spawnInterval;

    [SerializeField]private float timer;
    public Transform spawnArea;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;
    public int DeleteInterval;

    public GameObject ball;
    public float ballMagnitude;
    private float BallSpeedDuration;
    public bool activationBallSpeed;

    public GameObject PaddleKiri;
    public GameObject PaddleKanan;

    float durationScaleUpPaddleLeft ;
    float durationSpeedUpPaddleLeft ;
    float durationScaleUpPaddleRight ;
    float durationSpeedUpPaddleRight ;

    public bool activationScaleUpPaddleLeft = false;
    public bool activationSpeedUpPaddleLeft = false;
    public bool activationScaleUpPaddleRight = false;
    public bool activationSpeedUpPaddleRight = false;

    private List<GameObject> powerUpList;
    public List<GameObject> powerUpTemplateList;

    // Start is called before the first frame update
    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }


    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }



        if (activationBallSpeed == true)
        {
            if (BallSpeedDuration >= 5)
            {
                ball.GetComponent<BalController>().DeactivationPUSpeedUp(ballMagnitude);
                activationBallSpeed = false;
                BallSpeedDuration -= 5;
            }
            BallSpeedDuration += Time.deltaTime;
        }



        if (activationScaleUpPaddleLeft == true)
        {
            if (durationScaleUpPaddleLeft >= 5)
            {
                PaddleKiri.GetComponent<PlayerController>().ScaleDown(PaddleKiri);
                activationScaleUpPaddleLeft = false;
                durationScaleUpPaddleLeft -= 5;
            }
            durationScaleUpPaddleLeft += Time.deltaTime;
        }



        if (activationSpeedUpPaddleLeft == true)
        {
            if (durationSpeedUpPaddleLeft >= 5)
            {
                PaddleKiri.GetComponent<PlayerController>().ResetSpeedPad();
                activationSpeedUpPaddleLeft = false;
                durationSpeedUpPaddleLeft -= 5;
            }
            durationSpeedUpPaddleLeft += Time.deltaTime;
        }



        if (activationScaleUpPaddleRight == true)
        {
            if (durationScaleUpPaddleRight >= 5)
            {
                PaddleKanan.GetComponent<PlayerController>().ScaleDown(PaddleKanan);
                activationScaleUpPaddleRight = false;
                durationScaleUpPaddleRight -= 5;
            }
            durationScaleUpPaddleRight += Time.deltaTime;
        }



        if (activationSpeedUpPaddleRight == true)
        {
            if (durationSpeedUpPaddleRight >= 5)
            {
                PaddleKanan.GetComponent<PlayerController>().ResetSpeedPad();
                activationSpeedUpPaddleRight = false;
                durationSpeedUpPaddleRight -= 5;
            }
            durationSpeedUpPaddleRight += Time.deltaTime;
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }
    

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxPowerUpAmount)
        {
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

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
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
