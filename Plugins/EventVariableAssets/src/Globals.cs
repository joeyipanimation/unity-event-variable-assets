﻿using System;
namespace EventVariableAssets
{
    public static class Globals
    {
        /// <summary>
        /// Any newly serialized class should initialize itself with this version number
        /// </summary>
        public const string Version = "0.5";
        public static Version VersionNum { get => new Version(Version); }
    }
}
