using System;
using Paddles;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

namespace GameCore.ScriptableObjects
{
    //TODO: delete this or scriptable obj gameSettings
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/Game Settings")]
    public class GameSettings : ScriptableObject
    {
        public Boundaries PlayerBoundaries { private set; get; }
        public Boundaries AiBoundaries { private set; get; }

        [SerializeField] private float _playerMovementSpeed, _aiMovementSpeed;
        [SerializeField] private int _scoreRequiredToWin;
        [SerializeField] private KeyCode _resetPositionKey, _openMenuKey;
        [TextArea(10, 20)] [SerializeField] private string _howToPlayText;
        public float PlayerMovementSpeed => _playerMovementSpeed;
        public float AiMovementSpeed => _aiMovementSpeed;

        public string HowToPlayText => string.Format(_howToPlayText, _resetPositionKey.ToString(),
            _openMenuKey.ToString(), _scoreRequiredToWin.ToString());

        public void SetMovementBoundaries(IArenaScript arena)
        {
            var topBoundary = arena._playerBoundaryTransforms.Up.position.x;
            var bottomBoundary = arena._playerBoundaryTransforms.Down.position.x;
            var playerLeft = arena._playerBoundaryTransforms.Left.position.z;
            var playerRight = arena._playerBoundaryTransforms.Right.position.z;
            var aiLeft = arena._uiBoundaryTransforms.Left.position.z;
            var aiRight = arena._uiBoundaryTransforms.Right.position.z;
            PlayerBoundaries = new Boundaries(topBoundary, bottomBoundary, playerLeft, playerRight);
            AiBoundaries = new Boundaries(topBoundary, bottomBoundary, aiLeft, aiRight);
        }
    }
}