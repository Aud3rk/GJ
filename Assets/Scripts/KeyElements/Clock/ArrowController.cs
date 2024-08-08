using System;
using DG.Tweening;
using UnityEditor;
using UnityEngine;

namespace KeyElements
{
    public class ArrowController : MonoBehaviour
    {
        private void Update()
        {
            Vector3 diff = Camera.main.ScreenToViewportPoint(Input.mousePosition) - transform.position;
            float rotatZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0,0, rotatZ -90);
        }
    }
}