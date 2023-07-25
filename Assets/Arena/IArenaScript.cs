namespace Arena
{
    public interface IArenaScript
    {
        BoundaryTransforms _playerBoundaryTransforms { get; }
        BoundaryTransforms _uiBoundaryTransforms { get; }
    }
}