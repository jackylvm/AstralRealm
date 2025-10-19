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

using UnityEngine;
using static UnityEngine.Mathf;

namespace Basics.Lesson03
{
    public delegate Vector3 Function(float u, float v, float t);

    public enum FunctionName
    {
        Wave,
        MultiWave,
        Ripple,
        Sphere,
        Torus
    }

    public static class FunctionLibrary
    {
        private static Function[] functions = new Function[] { Wave, MultiWave, Ripple, Sphere, Torus };

        public static Function GetFunction(FunctionName name)
        {
            return functions[(int)name];
        }

        private static Vector3 Wave(float u, float v, float t)
        {
            // return Sin(PI * (x + z + t));
            Vector3 p;
            p.x = u;
            p.y = Sin(PI * (u + v + t));
            p.z = v;
            return p;
        }

        private static Vector3 MultiWave(float u, float v, float t)
        {
            /*
            // var y = Sin(PI * (x + t));
            var y = Sin(PI * (x + 0.5f * t));
            // y += 0.5f * Sin(2f * PI * (x + t));
            y += 0.5f * Sin(2f * PI * (z + t));
            y += Sin(PI * (x + z + 0.25f * t));
            return y * (1f / 2.5f);
            */
            Vector3 p;
            p.x = u;
            p.y = Sin(PI * (u + 0.5f * t));
            p.y += 0.5f * Sin(2f * PI * (u + t));
            p.y += Sin(PI * (u + v + 0.25f * t));
            p.y *= 1f / 2.5f;
            p.z = u;
            return p;
        }

        private static Vector3 Ripple(float u, float v, float t)
        {
            /*
            var d = Sqrt(x * x + z * z);
            // var y = Sin(4f * PI * d);
            var y = Sin(PI * (4f * d - t));
            return y / (1f + 10f * d);
            */
            Vector3 p;
            var d = Sqrt(u * u + v * v);
            p.x = u;
            p.y = Sin(PI * (4f * d - t));
            p.y /= 1f + 10f * d;
            p.z = v;
            return p;
        }

        private static Vector3 Sphere(float u, float v, float t)
        {
            /*
            var r = Cos(0.5f * PI * v);
            Vector3 p;
            p.x = r * Sin(PI * u);
            // p.y = v;
            p.y = Sin(0.5f * PI * v);
            p.z = r * Cos(PI * u);
            return p;
            */
            // var r = 0.5f + 0.5f * Sin(PI * t);
            // var r = 0.9f + 0.1f * Sin(8f * PI * u);
            // var r = 0.9f + 0.1f * Sin(8f * PI * v);
            var r = 0.9f + 0.1f * Sin(PI * (6f * u + 4f * v + t));
            var s = r * Cos(0.5f * PI * v);
            Vector3 p;
            p.x = s * Sin(PI * u);
            p.y = r * Sin(0.5f * PI * v);
            p.z = s * Cos(PI * u);
            return p;
        }

        private static Vector3 Torus(float u, float v, float t)
        {
            /*
            var r = 1f;
            var s = 0.5f + r * Cos(0.5f * PI * v);
            Vector3 p;
            p.x = s * Sin(PI * u);
            p.y = r * Sin(0.5f * PI * v);
            p.z = s * Cos(PI * u);
            return p;
            */
            /*
            var r = 1f;
            var s = 0.5f + r * Cos(PI * v);
            Vector3 p;
            p.x = s * Sin(PI * u);
            p.y = r * Sin(PI * v);
            p.z = s * Cos(PI * u);
            return p;
            */
            // const float r1 = 0.75f;
            // const float r2 = 0.25f;
            var r1 = 0.7f + 0.1f * Sin(PI * (6f * u + 0.5f * t));
            var r2 = 0.15f + 0.05f * Sin(PI * (8f * u + 4f * v + 2f * t));
            var s = r1 + r2 * Cos(PI * v);
            Vector3 p;
            p.x = s * Sin(PI * u);
            p.y = r2 * Sin(PI * v);
            p.z = s * Cos(PI * u);
            return p;
        }
    }
}