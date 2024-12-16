using UnityEngine;

namespace Game.UI
{
    public class Particler : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _startsEffectPrefab;

        private ParticleSystem _lastEffect;

        public void PlayRightCardEffect(Transform target)
        {
            _lastEffect = Instantiate(_startsEffectPrefab, target);
            _lastEffect.Play();
        }

        public void StopLastEffect() => _lastEffect?.Stop();
    }
}