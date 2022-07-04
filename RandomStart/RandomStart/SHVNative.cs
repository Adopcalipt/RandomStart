using System.Runtime.InteropServices;

namespace RandomStart
{
    //The Face blend data This part was from  E66666666/LeeC_HBD.cs, https://gist.github.com/E66666666/466c59df7aff69d2ac788fa38e669300
    public static class SHVNative
    {
        // These are borrowed from ScriptHookVDotNet's 
        [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?nativeInit@@YAX_K@Z")]
        static extern void NativeInit(ulong hash);

        [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?nativePush64@@YAX_K@Z")]
        static extern void NativePush64(ulong val);

        [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?nativeCall@@YAPEA_KXZ")]
        static extern unsafe ulong* NativeCall();

        // These are from ScriptHookV's nativeCaller.h
        static unsafe void NativePush<T>(T val) where T : unmanaged
        {
            ulong val64 = 0;
            *(T*)(&val64) = val;
            NativePush64(val64);
        }

        public static unsafe R Invoke<R>(ulong hash) where R : unmanaged
        {
            NativeInit(hash);
            return *(R*)(NativeCall());
        }

        // Apparently this works, but might be less efficient than C++'s variadic things
        public static unsafe R Invoke<R>(ulong hash, params dynamic[] args)
            where R : unmanaged
        {
            NativeInit(hash);

            foreach (var arg in args)
                NativePush(arg);

            return *(R*)(NativeCall());
        }
    }
}
