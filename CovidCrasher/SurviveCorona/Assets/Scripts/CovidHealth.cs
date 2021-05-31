using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CovidHealth : MonoBehaviour
{
    public int health = 10;
   
    public ParticleSystem deathParticles;
    public ParticleSystem hitParticles;

    public GameObject covid19;
    public GameObject covid;
    CinemachineVirtualCamera vcam;

    private void Awake()
    {
        vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
    }

    public void TakeDamage(int damageTaken)
    {
        hitParticles.Play();
        vcam.GetComponent<CameraShake>().Noise(1, 1);
        health = health - damageTaken;
        if (health <= 0)
        {
            Invoke("CovidDead", 0);
        }
    }

    void CovidDead()
    {
        deathParticles.Play();
        covid.SetActive(false);
        Invoke("DeleteCovid", 3);
    }

    void DeleteCovid()
    {
        Destroy(covid19);
    }


}
