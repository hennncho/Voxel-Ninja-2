using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem bloodEffect;    

    public void PlayEffect()
    {
        bloodEffect.Play();
    }
}
