using UnityEngine;

namespace Assets.Scripts
{
    public class SetDifferences : MonoBehaviour
    {
        [SerializeField] private GameObject _difference;
        [SerializeField] private Restart _restart;

        public GameObject Difference => _difference;

        private void Awake()
        {
            _difference = gameObject;

            SetRandomDifference();
        }

        private void OnEnable()
        {
            _restart._onRestarted += SetRandomDifference;
        }

        private void OnDisable()
        {
            _restart._onRestarted -= SetRandomDifference;
        }

        private void SetRandomDifference()
        {
            _difference.GetComponent<SpriteRenderer>().enabled = true;

            var random = Random.Range(0, 2);

            if (random > 0)
            {
                _difference.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}