using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Windows
{
    public abstract class ButtonBase : MonoBehaviour
    {
        private Button _button;
        
        private void Awake()
        {
            _button.onClick.AddListener(OnClick);
        }

        protected virtual void OnClick()
        {
        }
    }
}