using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace LevelManagement.CustomMenus.LevelSelector
{
    public class LevelSelector : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad = "";
        [SerializeField] private Sprite previewImage;
        
        private bool _isUnlocked = true;
        private Image _image;
        
        private void Awake()
        {
            _image = GetComponent<Image>();
            
            if (_isUnlocked && _image != null && previewImage != null)
            {
                _image.sprite = previewImage;
            }
        }

        public void OnLevelSelect()
        {
            if (_isUnlocked)
            {
                SceneManager.LoadScene(sceneToLoad);
                GameMenu.Open();
            }
        }
    }
}