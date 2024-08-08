using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchTimeAnimation : MonoBehaviour
{
    [SerializeField] GameObject CameraPP;
    [SerializeField] GameObject CameraLens;

    Animator _cameraPP;
    Animator _cameraLens;

    bool GoInPast = false;

    void Start()
    {
        _cameraPP = CameraPP.GetComponent<Animator>();
        _cameraLens = CameraLens.GetComponent<Animator>();
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
    }
}
