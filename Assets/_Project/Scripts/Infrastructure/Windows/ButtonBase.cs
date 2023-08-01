using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Windows
{
    public abstract class ButtonBase : MonoBehaviour
    {
        private Button _button;
        
        public virtual void Awake()
        {
            _button = gameObject.GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        public virtual void OnClick()
        {
        }
    }
}