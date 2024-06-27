using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SetEmissionSettings : MonoBehaviour
    {
        [SerializeField] private List<ParticleSystem> _particleSystems;

        public List<ParticleSystem> ParticleSystems => _particleSystems; 

        private void Start()
        {
            foreach (var item in _particleSystems)
            {
                item.emissionRate = 0;
            }
        }
    }
}