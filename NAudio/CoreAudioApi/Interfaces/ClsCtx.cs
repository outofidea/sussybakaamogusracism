﻿using System;

namespace NAudio.CoreAudioApi.Interfaces
{
    [Flags]
    internal enum ClsCtx
    {
        INPROC_SERVER = 1,
        INPROC_HANDLER = 2,
        LOCAL_SERVER = 4,
        INPROC_SERVER16 = 8,
        REMOTE_SERVER = 16,
        INPROC_HANDLER16 = 32,
        NO_CODE_DOWNLOAD = 1024,
        NO_CUSTOM_MARSHAL = 4096,
        ENABLE_CODE_DOWNLOAD = 8192,
        NO_FAILURE_LOG = 16384,
        DISABLE_AAA = 32768,
        ENABLE_AAA = 65536,
        FROM_DEFAULT_CONTEXT = 131072,
        ACTIVATE_32_BIT_SERVER = 262144,
        ACTIVATE_64_BIT_SERVER = 524288,
        ENABLE_CLOAKING = 1048576,
        PS_DLL = -2147483648,
        INPROC = 3,
        SERVER = 21,
        ALL = 23
    }
}
