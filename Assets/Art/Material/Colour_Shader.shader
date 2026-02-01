Shader "UI/PsychedelicRainbow"
{
    Properties
    {
        _Speed ("Color Cycle Speed", Float) = 1
        _Saturation ("Saturation", Range(0,2)) = 1
        _Brightness ("Brightness", Range(0,2)) = 1
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off
        ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            float _Speed;
            float _Saturation;
            float _Brightness;

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float3 HSVtoRGB(float3 hsv)
            {
                float4 K = float4(1., 2./3., 1./3., 3.);
                float3 p = abs(frac(hsv.xxx + K.xyz) * 6. - K.www);
                return hsv.z * lerp(K.xxx, saturate(p - K.xxx), hsv.y);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float hue = frac(_Time.y * _Speed);
                float3 rgb = HSVtoRGB(float3(hue, _Saturation, _Brightness));
                return fixed4(rgb, 1);
            }
            ENDCG
        }
    }
}
