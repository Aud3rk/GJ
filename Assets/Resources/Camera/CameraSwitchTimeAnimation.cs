using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchTimeAnimation : MonoBehaviour
{
    [SerializeField] GameObject CameraPP;
    [SerializeField] GameObject CameraLens;
    [SerializeField] GameObject CameraLens2;
    [SerializeField] public AudioSource _audioSource;
    [SerializeField] public AudioSource _audioSource2;


    Animator _cameraPP;
    Animator _cameraLens;
    Animator _cameraLens2;

    public bool GoInPast = false;

    void Start()
    {
        _cameraPP = CameraPP.GetComponent<Animator>();
        _cameraLens = CameraLens.GetComponent<Animator>();
        _cameraLens2 = CameraLens2.GetComponent<Animator>();
    }
    
    public void GoInTimeAnimation()
    {
        GoInPast = !GoInPast;
        _cameraPP.SetBool("GoInPast", GoInPast);
        _cameraLens.SetBool("GoInPast", GoInPast);
        _cameraLens2.SetBool("GoInPast", GoInPast);
    }
}
