using Paddles;
using VContainer.Unity;
using EventBus = GameCore.Events.EventBus;

namespace GameCore
{
    
    
    //TODO: delete this or scriptable obj gameSettings
    public class GameplaySettings
    {
        public Boundaries PlayerBoundaries { get; }
        public Boundaries AiBoundaries { get; }

        private IArenaScript _arena;

        private GameplaySettings(IArenaScript arena, EventBus bus)
        {
            _arena = arena;
            var topBoundary = _arena._playerBoundaryTransforms.Up.position.x;
            var bottomBoundary = _arena._playerBoundaryTransforms.Down.position.x;
            var playerLeft = _arena._playerBoundaryTransforms.Left.position.z;
            var playerRight = _arena._playerBoundaryTransforms.Right.position.z;
            var aiLeft = _arena._uiBoundaryTransforms.Left.position.z;
            var aiRight = _arena._uiBoundaryTransforms.Right.position.z;
            PlayerBoundaries = new Boundaries(topBoundary, bottomBoundary, playerLeft, playerRight);
            AiBoundaries = new Boundaries(topBoundary, bottomBoundary, aiLeft, aiRight);
        }
    }
}