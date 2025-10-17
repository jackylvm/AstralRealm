// ***********************************************************************************
// FileName: Lesson03.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2025-10-16 21:43:24
// ==============================================
// History update record:
// 
// ==============================================
// *************************************************************************************

using UnityEngine;

namespace Basics.Lesson03
{
    public class Lesson03 : MonoBehaviour
    {
        [SerializeField] private Transform pointPrefab;
        [SerializeField, Range(1, 100)] private int resolution = 10;
        [SerializeField] private FunctionName waveType;

        private Transform[] points;

        /// <summary>
        /// Awake 函数会在游戏对象被实例化之后立即调用，而且在所有对象的 Start 函数调用之前执行。一般在 Awake 函数里进行以下操作：
        /// <para>1. 初始化引用：查找并存储对其他组件或者游戏对象的引用，确保后续代码能够方便地访问这些对象。</para>
        /// <para>2. 初始化设置：对脚本中的变量进行初始赋值。</para>
        /// <para>3. 建立连接：比如和数据库或者网络服务建立连接。</para>
        /// </summary>
        private void Awake()
        {
            var step = 2.0f / resolution;
            var scale = Vector3.one * step;
            var position = Vector3.zero;

            points = new Transform[resolution * resolution];
            for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
            {
                if (x == resolution)
                {
                    x = 0;
                    z++;
                }

                position.x = (x + 0.5f) * step - 1.0f;
                position.z = (z + 0.5f) * step - 1.0f;
                position.y = 0;

                var point = Instantiate(pointPrefab, transform, false);
                point.localScale = scale;
                point.localPosition = position;

                points[i] = point;
            }
        }

        private void Update()
        {
            var time = Time.time;
            var func = FunctionLibrary.GetFunction(waveType);
            foreach (var point in points)
            {
                var position = point.localPosition;
                position.y = func(position.x, position.z, time);
                point.localPosition = position;
            }
        }
    }
}