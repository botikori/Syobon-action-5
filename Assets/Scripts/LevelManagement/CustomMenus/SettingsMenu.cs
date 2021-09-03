using UnityEngine;
using UnityEngine.UI;
using MenuManagement.Data;

namespace MenuManagement
{
    public class SettingsMenu : Menu<SettingsMenu>
    {
        [SerializeField] private Slider musicVolumeSlider;
        [SerializeField] private Slider soundEffectsVolumeVolumeSlider;

        private DataManager _dataManager;

        protected override void Awake()
        {
            base.Awake();
            _dataManager = FindObjectOfType<DataManager>();
        }

        public void Start()
        {

            LoadData();
        }

        public void OnMusicVolumeChanged(float volume)
        {
            if (_dataManager != null)
            {
                _dataManager.MusicVolume = volume;
            }
        }

        public void OnSoundEffectsVolumeChanged(float volume)
        {
            if (_dataManager != null)
            {
                _dataManager.SoundEffectsVolume = volume;
            }
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            if (_dataManager != null)
            {
                _dataManager.Save();
            }
        }

        public void LoadData()
        {
            if (musicVolumeSlider == null || soundEffectsVolumeVolumeSlider == null || _dataManager == null)
            {
                return;
            }
            _dataManager.Load();

            musicVolumeSlider.value = _dataManager.MusicVolume;
            soundEffectsVolumeVolumeSlider.value = _dataManager.SoundEffectsVolume;
        }
    }
}