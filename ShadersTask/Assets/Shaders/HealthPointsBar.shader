Shader "Unlit/HealthPointsBar"
{
    Properties
    {
        _Health ("Health", Range(0,1)) = 0
        _LowHealthColor("Low Health Color", Color) = (1,0,0,1) // Red
        _HighHealthColor("High Health Color", Color) = (0,1,0,1) // Green
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float _Health;
            fixed4 _LowHealthColor;
            fixed4 _HighHealthColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                if (i.uv.x > _Health)
                {
                    return 1;
                }
                return lerp(_LowHealthColor, _HighHealthColor, _Health);
            }
            ENDCG
        }
    }
}