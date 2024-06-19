using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configuracoes : MonoBehaviour
{
    public Movement movement;
    [SerializeField] private float maxSliderSpeed = 20f, maxSliderRot = 0.01f;
    void Awake()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }
    public void Speed(float value)
    {
        if(movement != null)
        movement._speed = value * maxSliderSpeed;
    }
    public void Sensibilidade(float value)
    {
        if(movement != null)
        movement._rotateSpeed = value * maxSliderRot;
    }
    public void Sound(float value)
    {
        AudioController.AudioInstance.audioSourceMusicaDeFundo.volume = value; 
    }
}
