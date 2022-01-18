using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Inimigo;
    [SerializeField]
    private float tempoInimigo = 1f;
    private float tempoVerifInimigo;
    [SerializeField]
    private GameObject[] PowerUps;
    [SerializeField]
    private float[] tempoPowerUp;
    private float[] tempoVerifPowerUp = new float[3];

    void Start()
    {
        tempoVerifPowerUp[0] = tempoPowerUp[0];
        tempoVerifPowerUp[1] = tempoPowerUp[1];
        tempoVerifPowerUp[2] = tempoPowerUp[2];
    }

    void Update()
    {
        if(Time.time > tempoVerifInimigo)
        {
            tempoVerifInimigo = Time.time + tempoInimigo;
            Instantiate(Inimigo, new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
        }

        int objetoUP = Random.Range(0, 3);
        if (Time.time > tempoVerifPowerUp[objetoUP])
        {
            tempoVerifPowerUp[objetoUP] = Time.time + tempoPowerUp[objetoUP];
            Instantiate(PowerUps[objetoUP], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
        }
    }
}
