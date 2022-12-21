using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace Ruinum.ECS.Scripts.UI.Windows.Loader 
{
    public sealed class LoaderWindow : MonoBehaviour
    {
        [SerializeField] private Slider _progressBarImage = default;
        [SerializeField] private TMP_Text _progressBarText = default;

        public void UpdateProgress(float progress)
        {
            _progressBarImage.value = progress;
            _progressBarText.text = $"{(int) (progress * 100)} %";
        }
    }
}