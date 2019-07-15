using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Components;
using Damselfly.Components.Input.Routing;

namespace Damselfly.Components.Input
{
    public class GlobalHotkeyController //: IConfirmationSource, IInputSink<ISetGlobalHotkeySource>, IInputSink<IGlobalHotkeySource>
    {
        public event EventHandler<HotkeyBindingEventAgs> OverwritingKeyBinding;

        private Dictionary<string, GlobalHotkeyBinding> _globalBindings = new Dictionary<string, GlobalHotkeyBinding>();

        public void Init() => JsonRepository.LoadOrCreate(out _globalBindings);

        public void SetGlobalHotkey(Key key, string command)
        {
            var keyStr = key.ToString();

            if (_globalBindings.TryGetValue(keyStr, out var binding))
            {
                var e = new HotkeyBindingEventAgs(key, command);
                OverwritingKeyBinding?.Invoke(this, e);

                if (e.IsCanceled)
                {
                    return;
                }
            }
            else
            {
                _globalBindings.Add(keyStr, binding = new GlobalHotkeyBinding(key));
            }

            binding.Command = command;
            JsonRepository.Save(_globalBindings);
        }

        public void HandleGlobalHotkey(Key key)
        {
            if (!_globalBindings.TryGetValue(key.ToString().ToString(), out var binding))
            {
                return;
            }
            
            Launcher.Launch(binding.Command, asAdmin: false);
        }

        //public void Listen(IInputSource inputSource) => throw new NotImplementedException();
        
        //public void Broadcast(IInputSink inputSource) => throw new NotImplementedException();

        //public void Listen(ISetGlobalHotkeySource inputSource) =>
        //    inputSource.SetGlobalHotkeyPressed += (o, e) => SetGlobalHotkey(e.Key, e.Binding);

        //public void Listen(IGlobalHotkeySource inputSource) =>
        //    inputSource.GlobalHotkeyPressed += (o, e) => HandleGlobalHotkey(e.Key);
        
    }
}
