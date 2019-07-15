namespace Damselfly.Components.Input.Routing
{
    public interface IInputSink : IInputObject
    {
        //void Listen(IInputSource inputSource);
    }

    public interface IInputSink<TInputSource> : IInputSink
        where TInputSource : IInputSource
    {
        void Listen(TInputSource inputSource);
    }
}