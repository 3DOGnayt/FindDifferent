using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class DifferenceList : MonoBehaviour
    {
        [SerializeField] private Tap _tap;
        [SerializeField] private Restart _restart;
        [Space(10)]
        [SerializeField] private List<SpriteRenderer> _spriteRenderersUp;
        [SerializeField] private List<SpriteRenderer> _spriteRenderersDown;
        [Space(10)]
        [SerializeField] private TMP_Text _differenceCountText;
        [SerializeField] private int _differenceCount; 
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private int _level; 

        public List<SpriteRenderer> SpriteRenderersUp => _spriteRenderersUp;
        public List<SpriteRenderer> SpriteRenderersDown => _spriteRenderersDown;
        public int DifferenceCount => _differenceCount;
        public int Level => _level;

        private void Start()
        {
            _level = 1;

            SetDifferenceCount();

            SetDifferenceCountText();

            SetLevelText();
        }

        private void OnEnable()
        {
            _tap._onFindDifference += ChangeDifferenceCount;
            _restart._onRestarted += Changelevel;
            _restart._onRestarted += SetDifferenceCount;
        }

        private void OnDisable()
        {
            _tap._onFindDifference -= ChangeDifferenceCount;
            _restart._onRestarted -= Changelevel;
            _restart._onRestarted -= SetDifferenceCount;
        }

        private void SetDifferenceCountText() => _differenceCountText.text = $"Difference Count {_differenceCount}";

        private void SetLevelText() => _levelText.text = $"Level {_level}";

        private void SetDifferenceCount()
        {
            _differenceCount = 0;

            foreach (var item in _spriteRenderersUp)
            {
                if (item.enabled)
                    _differenceCount += 1;
            }

            SetDifferenceCountText();
        }

        private void ChangeDifferenceCount() 
        {
            _differenceCount -= 1;

            SetDifferenceCountText();
        }

        private void Changelevel()
        {
            _level += 1;

            SetLevelText();
        }
    }
}