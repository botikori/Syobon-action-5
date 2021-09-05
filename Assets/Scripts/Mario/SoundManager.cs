using UnityEngine;

namespace Mario
{
    public class SoundManager : Singleton<SoundManager>
    {
        // Audio players components.
        [SerializeField] private AudioSource effectsSource;
        [SerializeField] private AudioSource musicSource;
        
        [SerializeField] private AudioClip music;

        private void Start()
        {
            if (music != null)
            {
                PlayMusic(music);
            }
        }

        public void UpdateMusicVolume(float volume)
        {
            musicSource.volume = volume;
        }

        public void UpdateSoundEffectsVolume(float volume)
        {
            effectsSource.volume = volume;
        }
        
        public void PlaySound(AudioClip clip)
        {
            if (clip != null)
            {
                effectsSource.clip = clip;
                effectsSource.Play();
            }
            
        }
        
        public void PlayMusic(AudioClip clip)
        {
            if (clip != null)
            {
                musicSource.clip = clip;
                musicSource.Play();
            }
        }

        public void StopMusic()
        {
            musicSource.Stop();
        }
    }
}