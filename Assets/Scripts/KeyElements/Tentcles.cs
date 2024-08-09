using DG.Tweening;
using UnityEngine;

namespace KeyElements
{
    public class Tentcles : MonoBehaviour
    {
        private int bookCorrect = 5;

        public void RightBook()
        {
            bookCorrect--;
            if (bookCorrect == 0)
            {
                DOTween.Sequence().Append(transform.DOScale(Vector3.zero, 2f)).AppendInterval(1f);
                //transform.gameObject.SetActive(false);
            }
        }

    }
}