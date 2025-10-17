Shader "Jacky/Basics/Lesson03"
{
    Properties
    {
        _Smoothness("Smoothness",Range(0,1)) = 0.5
    }
    SubShader
    {
        CGPROGRAM
        #pragma surface ConfigureSurface Standard fullforwardshadows
        #pragma target 3.0

        struct Input
        {
            float3 worldPos;
        };

        float _Smoothness;

        void ConfigureSurface(Input input, inout SurfaceOutputStandard output)
        {
            output.Albedo = saturate(input.worldPos * 0.5 + 0.5);
            output.Smoothness = _Smoothness;
        }
        ENDCG
    }
    Fallback "Legacy Shaders/Diffuse"
}