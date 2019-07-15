namespace Damselfly.Components.Input.Routing
{
    public interface IInputSource : IInputObject
    {
        void Broadcast(IInputSink inputSource);
    }
}