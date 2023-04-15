using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] public AudioClip _spawnSound;
        [SerializeField] public AudioClip _removeSound;

		private AudioSource _audioSource;
        

        private void Awake()
        {
            //TODO: What's a better way to implement this singleton?
            // var gameManagers = FindObjectsOfType<GameManager>();
            
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(this);   
            }

			_audioSource = GetComponent<AudioSource>();
        }

        public void PlaySpawnSound()
        {
            _audioSource.PlayOneShot(_spawnSound);

        }

		public void PlayRemoveSound()
		{
		    _audioSource.PlayOneShot(_removeSound);
		}
        
        
    }
}