// ***********************************************************************************
// FileName: FunctionLibrary.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2025-10-16 21:46:56
// ==============================================
// History update record:
// 
// ==============================================
// *************************************************************************************

using static UnityEngine.Mathf;

namespace Basics.Lesson03
{
    public delegate float Function(float x, float z, float t);

    public enum FunctionName
    {
        Wave,
        MultiWave,
        Ripple
    }

    public static class FunctionLibrary
    {
        private static Function[] functions = new Function[] { Wave, MultiWave, Ripple };

        public static Function GetFunction(FunctionName name)
        {
            return functions[(int)name];
        }

        private static float Wave(float x, float z, float t)
        {
            return Sin(PI * (x + z + t));
        }

        private static float MultiWave(float x, float z, float t)
        {
            // var y = Sin(PI * (x + t));
            var y = Sin(PI * (x + 0.5f * t));
            // y += 0.5f * Sin(2f * PI * (x + t));
            y += 0.5f * Sin(2f * PI * (z + t));
            y += Sin(PI * (x + z + 0.25f * t));
            return y * (1f / 2.5f);
        }

        private static float Ripple(float x, float z, float t)
        {
            var d = Sqrt(x * x + z * z);
            // var y = Sin(4f * PI * d);
            var y = Sin(PI * (4f * d - t));
            return y / (1f + 10f * d);
        }
    }
}