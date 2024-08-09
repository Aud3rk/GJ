using System;
using System.Collections;
using System.Collections.Generic;
using Cube;
using DG.Tweening;
using Resources.Scripts;
using UnityEngine;
using UnityEngine.Events;
using Wheel;

public class CubeController : MonoBehaviour
{
    public UnityEvent CubeIsSolved;
    [SerializeField] private float neededRotation;
    [SerializeField] private LogicArrow[] codeToSolve;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform clone;
    [SerializeField] private Vector3 VectorUp;
    [SerializeField] private Vector3 VectorDown;
    [SerializeField] private Vector3 VectorLeft;
    [SerializeField] private Vector3 VectorRight;
    private AudioSource _audioSource;

    private LogicArrow[] actualCode;
    private int i = 0;
    public InputManager InputManager { get; set; }

    private void OnEnable()
    {
         _audioSource = Camera.main.GetComponent<MusicProvider>().AudioSource;

    }


    private void Update()
    {
        if (InputManager.PlayerPickUp())
        {
            gameObject.GetComponent<CubeKeeper>().EndInteract();
        }
        else
        {
            if (InputManager.ControllCubeW())
            {
                _audioSource.Play();
                if (codeToSolve[i] == LogicArrow.Up)
                {
                    clone.transform.RotateAround(parent.transform.localPosition, VectorUp, 90);
                    transform.DORotate(clone.transform.rotation.eulerAngles, 0.45f);
                    i++;
                }
                else
                {
                    i = 0;
                    gameObject.GetComponent<CubeKeeper>().EndInteract();
                    
                }
            }
            if (InputManager.ControllCubeS())
            {
                _audioSource.Play();

                if (codeToSolve[i] == LogicArrow.Down)
                {
                    clone.transform.RotateAround(parent.transform.position, VectorDown, 90);
                    transform.DORotate(clone.transform.rotation.eulerAngles, 0.45f);
                    i++;
                }
                else
                {
                    i = 0;
                    gameObject.GetComponent<CubeKeeper>().EndInteract();
                    
                }
            }
            if (InputManager.ControllCubeA())
            {
                _audioSource.Play();

                if (codeToSolve[i] == LogicArrow.Left)
                {
                    clone.transform.RotateAround(parent.transform.position, VectorLeft, 90);
                    transform.DORotate(clone.transform.rotation.eulerAngles, 0.45f);
                    i++;
                }
                else
                {
                    i = 0;
                    gameObject.GetComponent<CubeKeeper>().EndInteract();
                    
                }
            }
            if (InputManager.ControllCubeD())
            {
                _audioSource.Play();

                if (codeToSolve[i] == LogicArrow.Right)
                {
                    clone.transform.RotateAround(parent.transform.position, VectorRight, 90);
                    transform.DORotate(clone.transform.rotation.eulerAngles, 0.45f);
                    i++;
                }
                else
                {
                    i = 0;
                    gameObject.GetComponent<CubeKeeper>().EndInteract();
                    
                }
            }
            if (i==6)
            {
                Camera.main.GetComponent<MusicProvider>().AudioSource1.Play();
                CubeIsSolved.Invoke();
            }
        }
            
    }

    public void CubeIsCorrect()
    {
        DOTween.Sequence().Append(transform.DOScale(Vector3.zero, 1f)).Append(parent.transform.DOScale(Vector3.zero, 1f));
        gameObject.GetComponent<CubeKeeper>().EndInteract();
    }

    enum LogicArrow
    {
        Up,
        Down,
        Left,
        Right
    }
}