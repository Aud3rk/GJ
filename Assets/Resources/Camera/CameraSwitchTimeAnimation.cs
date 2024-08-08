using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchTimeAnimation : MonoBehaviour
{
    [SerializeField] GameObject CameraPP;
    [SerializeField] GameObject CameraLens;
    [SerializeField] GameObject CameraLens2;

    Animator _cameraPP;
    Animator _cameraLens;
    Animator _cameraLens2;

    bool GoInPast = false;

    void Start()
    {
        _cameraPP = CameraPP.GetComponent<Animator>();
        _cameraLens = CameraLens.GetComponent<Animator>();
        _cameraLens2 = CameraLens2.GetComponent<Animator>();
    }
    void Update() //Вот это нахуй уберешь не хочу лезть в твою инпут систему
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GoInTimeAnimation();
        }
    }
    public void GoInTimeAnimation()
    {
        if (!GoInPast)
            GoInPast = true;
        else
            GoInPast = false;

        _cameraPP.SetBool("GoInPast", GoInPast);
        _cameraLens.SetBool("GoInPast", GoInPast);
        _cameraLens2.SetBool("GoInPast", GoInPast);
    }
}
