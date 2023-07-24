using System;
using TMPro;
using UnityEngine;

namespace GameCore.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreView : MonoBehaviour
    {
        private TextMeshProUGUI _scoreText;
        
        private void Start()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }
    }
}
