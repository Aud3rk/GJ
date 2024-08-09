using DG.Tweening;
using UnityEngine;

namespace KeyElements
{
    public class CatHolder : MonoBehaviour
    {
        public int Index;
        public Transform KeyPos; 
        private GameObject key;

        public GameObject Key
        {
            get { return key; }
            set { key=value;}
        }
        public bool KeyIsOn
        {
            get;
            private set;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Key>().Index == 404)
            {

                other.GetComponent<PickUpController>().StopPickUp();
                other.GetComponent<Collider>().enabled = false;
                other.transform.parent = null;
                other.transform.position = new Vector3(1.577f, 0.464f, -124.71f);
                other.transform.rotation = Quaternion.Euler(new Vector3(75,417,79));
                other.GetComponent<Animator>().enabled = true;
                other.GetComponent<Animation>().enabled = true;
                other.GetComponent<Animator>().SetBool("Trigger", true);
                transform.DOScale(new Vector3(transform.localScale.x, 0.01f, transform.localScale.z), 4);
                KeyPos.gameObject.GetComponent<LampRoom2>()._inscription = "Этот кот неплохо бы смотрелся в рамке";
                transform.GetComponent<Collider>().enabled = false;
                KeyPos.gameObject.GetComponent<Collider>().enabled = true;
            }
        }
    }
    
}