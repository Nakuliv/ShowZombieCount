using System;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Loader;
using System.Reflection;

using PlayerEv = Exiled.Events.Handlers.Player;
using ServerEv = Exiled.Events.Handlers.Server;

namespace ShowZombieCount
{
    public class Plugin : Plugin<Config>
    {
        public override PluginPriority Priority => PluginPriority.Default;

        public override string Name { get; } = "ShowZombieCount";
        public override string Author { get; } = "Naku (Cwaniaak.)";
        public override Version Version => new Version(1, 4, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        private EventHandlers handlers;

        public override void OnEnabled()
        {
            handlers = new EventHandlers();
            Plugin.Singleton = this;
            PlayerEv.ChangingRole += handlers.OnChangingRole;
            PlayerEv.Died += handlers.OnPlayerDied;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            handlers = null;
            PlayerEv.ChangingRole -= handlers.OnChangingRole;
            PlayerEv.Died -= handlers.OnPlayerDied;
            base.OnDisabled();
        }

        public static Plugin Singleton;
    }
}
