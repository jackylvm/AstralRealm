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

using System;
using UnityEngine;

namespace Basics.Lesson03
{
    public class Lesson03 : MonoBehaviour
    {
        [SerializeField] private Transform pointPrefab;
        [SerializeField, Range(1, 100)] private int resolution = 10;

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

            points = new Transform[resolution];
            for (var i = 0; i < points.Length; i++)
            {
                position.x = (i + 0.5f) * step - 1.0f;
                position.y = FunctionLibrary.Wave(position.x, 0.0f);

                var point = Instantiate(pointPrefab, transform, false);
                point.localScale = scale;
                point.localPosition = position;

                points[i] = point;
            }
        }

        private void Update()
        {
            var time = Time.time;
            foreach (var point in points)
            {
                var position = point.localPosition;
                position.y = FunctionLibrary.Wave(position.x, time);
                point.localPosition = position;
            }
        }
    }
}