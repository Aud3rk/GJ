using System.Collections;
using UnityEngine;

interface ICoroutineRunner
{
    Coroutine StartCoroutine(IEnumerator coroutine);
}