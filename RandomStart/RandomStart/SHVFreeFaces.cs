using GTA;
using GTA.Native;
using System;
using System.Runtime.InteropServices;

namespace RandomStart
{
    public class SHVFreeFaces
    {
        [StructLayout(LayoutKind.Explicit, Size = 80)]
        public struct HeadBlendData
        {
            [FieldOffset(0)] public int shapeFirstID;
            [FieldOffset(8)] public int shapeSecondID;
            [FieldOffset(16)] public int shapeThirdID;
            [FieldOffset(24)] public int skinFirstID;
            [FieldOffset(32)] public int skinSecondID;
            [FieldOffset(40)] public int skinThirdID;
            [FieldOffset(48)] public float shapeMix;
            [FieldOffset(56)] public float skinMix;
            [FieldOffset(64)] public float thirdMix;
            [FieldOffset(72)] public int isParent;
        }
        public static unsafe HeadBlendData GetHeadBlendData(Ped Peddy)
        {
            HeadBlendData hbd = new HeadBlendData() { shapeFirstID = -1 };
            HeadBlendData* pHbd = &hbd;

            bool result = SHVNative.Invoke<bool>((ulong)Hash._GET_PED_HEAD_BLEND_DATA, Peddy.Handle, (IntPtr)pHbd);

            // result handling might be useful

            return *pHbd;
        }
    }
}
