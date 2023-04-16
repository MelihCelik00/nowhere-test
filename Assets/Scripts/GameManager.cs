using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager : SingletonBehaviour<GameManager>
    {

        [SerializeField] public AudioClip _spawnSound;
        [SerializeField] public AudioClip _removeSound;

		private AudioSource _audioSource;


		protected override void Awake()
        {
	        base.Awake();
            //TODO: What's a better way to implement this singleton?
            // Implemented SingletonBehaviour Class

			_audioSource = GetComponent<AudioSource>();
			SpawnManager.OnInstantiate += PlaySpawnSound;
			SpawnManager.OnRemove += PlayRemoveSound;
        }
        
        private void OnDestroy()
		{
			SpawnManager.OnInstantiate -= PlaySpawnSound;
			SpawnManager.OnRemove -= PlayRemoveSound;
		}

        private void PlaySpawnSound()
        {
            _audioSource.PlayOneShot(_spawnSound);
        }

		private void PlayRemoveSound()
		{
		    _audioSource.PlayOneShot(_removeSound);
		}
        
        
    }
}