Shader "UI/PoliceStrobe"
{
    Properties
    {
        _Speed ("Strobe Speed (Hz)", Float) = 4
        _RedColor ("Red Color", Color) = (1,0,0,1)
        _BlueColor ("Blue Color", Color) = (0,0,1,1)
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
            fixed4 _RedColor;
            fixed4 _BlueColor;

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Square wave strobe
                float t = floor(_Time.y * _Speed) % 2;
                return lerp(_RedColor, _BlueColor, t);
            }
            ENDCG
        }
    }
}
