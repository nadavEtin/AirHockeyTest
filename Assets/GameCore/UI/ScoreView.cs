using TMPro;
using UnityEngine;

namespace GameCore.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreView : MonoBehaviour, IScoreView
    {
        public TextMeshProUGUI ScoreText { get; set; }
        
        private void Start()
        {
            ScoreText = GetComponent<TextMeshProUGUI>();
        }
    }
}
