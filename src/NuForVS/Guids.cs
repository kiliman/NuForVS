// Guids.cs
// MUST match guids.h
using System;

namespace NuForVS
{
    static class GuidList
    {
        public const string guidNuForVSPkgString = "51cd7ebb-b5e6-46fd-aeae-05841440deaa";
        public const string guidNuForVSCmdSetString = "3754a95f-3492-47b7-97c5-ef173806e1ec";

        public static readonly Guid guidNuForVSCmdSet = new Guid(guidNuForVSCmdSetString);
    };
}