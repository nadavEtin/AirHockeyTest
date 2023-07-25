using GameCore.ScriptableObjects;
using UnityEngine;
using VContainer;

namespace Arena
{
        public struct BoundaryTransforms
        {
                public Transform Up, Down, Left, Right;

                public BoundaryTransforms(Transform up, Transform down, Transform left, Transform right)
                {
                        Up = up;
                        Down = down;
                        Left = left;
                        Right = right;
                }
        }
        
        public class ArenaScript : MonoBehaviour, IArenaScript
        {
                [SerializeField] private Transform _playerUp, _playerDown, _playerRight, _playerLeft;
                [SerializeField] private Transform _uiUp, _uiDown, _uiLeft, _uiRight;

                public BoundaryTransforms _playerBoundaryTransforms { private set; get;} 
                public BoundaryTransforms _uiBoundaryTransforms { private set; get;}

                [Inject]
                private void Construct(GameSettings settings)
                {
                        _playerBoundaryTransforms = new BoundaryTransforms(_playerUp, _playerDown, _playerLeft, _playerRight);
                        _uiBoundaryTransforms = new BoundaryTransforms(_uiUp, _uiDown, _uiLeft, _uiRight);
                        settings.SetMovementBoundaries(this);
                }
        }
}