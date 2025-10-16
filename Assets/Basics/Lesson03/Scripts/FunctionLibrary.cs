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
    public delegate float Function(float x, float t);

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

        public static float Wave(float x, float t)
        {
            return Sin(PI * (x + t));
        }

        public static float MultiWave(float x, float t)
        {
            // var y = Sin(PI * (x + t));
            var y = Sin(PI * (x + 0.5f * t));
            y += 0.5f * Sin(2f * PI * (x + t));
            return y * (2f / 3f);
        }

        public static float Ripple(float x, float t)
        {
            var d = Abs(x);
            // var y = Sin(4f * PI * d);
            var y = Sin(PI * (4f * d - t));
            return y / (1f + 20f * d);
        }
    }
}