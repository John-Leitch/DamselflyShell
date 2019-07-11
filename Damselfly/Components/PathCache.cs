using System;
using Components;

namespace Damselfly.Components
{
    public static class PathCache
    {
        public static ArgLockingMemoizer<string, T> Create<T>() =>
            new ArgLockingMemoizer<string, T>(StringComparer.OrdinalIgnoreCase);
    }
}
