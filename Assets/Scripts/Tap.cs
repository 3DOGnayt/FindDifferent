using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Tap : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private DifferenceList _list;
        [SerializeField] private Restart _restart;

        private RaycastHit Hit;

        public event Action _onFindDifference;

        private void Start() => _camera = Camera.main;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                FindDifference();
        }

        private void OnEnable()
        {
            _restart._onRestarted += OnColliders;
        }

        private void OnDisable()
        {
            _restart._onRestarted -= OnColliders;
        }

        private void FindDifference()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(_camera.transform.position, ray.direction * 11f, Color.green);

            Physics.Raycast(ray, out Hit, 11f);

            if (Hit.collider == null)
                return;

            if (Hit.collider.gameObject.TryGetComponent(out SpriteRenderer component))
            {
                for (int i = 0; i < _list.SpriteRenderersUp.Count; i++)
                {
                    var up = _list.SpriteRenderersUp[i];

                    var down = _list.SpriteRenderersDown[i];

                    if ((component == up) && component.enabled)
                    {
                        StartCoroutine(OffParticles(up, down));

                        _onFindDifference.Invoke();                 
                    }

                    if ((component == down) && _list.SpriteRenderersUp[i].enabled)
                    {
                        StartCoroutine(OffParticles(down, up));

                        _onFindDifference.Invoke();
                    }
                }
            }
        }

        private IEnumerator OffParticles(SpriteRenderer item, SpriteRenderer second)
        {
            item.GetComponent<ParticleSystem>().emissionRate = 50;
            item.gameObject.GetComponent<Collider>().enabled = false;
            second.gameObject.GetComponent<Collider>().enabled = false;
            yield return new WaitForSeconds(1.5f);
            item.GetComponent<ParticleSystem>().emissionRate = 0;
        }

        private void OnColliders()
        {
            for (int i = 0; i < _list.SpriteRenderersUp.Count; i++)
            {
                _list.SpriteRenderersUp[i].gameObject.GetComponent<Collider>().enabled = true;
                _list.SpriteRenderersDown[i].gameObject.GetComponent<Collider>().enabled = true;
            }           
        }
    }
}