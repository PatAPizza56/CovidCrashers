using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLocation : MonoBehaviour
{
    public GameObject player;

    public ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem.Stop();
    }
    void Update()
    {
        transform.position = player.transform.position;
    }
}
