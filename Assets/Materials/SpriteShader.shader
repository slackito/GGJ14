Shader "Custom/SpriteShader" {
	Properties {
		_MainTex ("Light texture (RGB)", Rect) = "white" {}
		_DarkTex ("Dark texture (RGB)", Rect) = "gray" {}
		_FadeState ("Fade state (float)", Float) = 1.0
	}
	SubShader {
		Tags { 
			"RenderType"="Transparent"
			"Queue"="Transparent"
		}
		
		Blend SrcAlpha OneMinusSrcAlpha
		
		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			sampler2D _DarkTex;
			float _FadeState;

			struct v2f {
			    float4 pos : SV_POSITION;
	    		float2  uv : TEXCOORD0;
			};

			v2f vert (appdata_base v)
			{
			    v2f o;
			    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
			    o.uv = MultiplyUV(UNITY_MATRIX_TEXTURE0, v.texcoord);
			    return o;
			}

			float4 frag (v2f i) : COLOR
			{
			    float4 cl = tex2D(_MainTex, i.uv);
			    cl.rgb *= cl.a; 
			    float4 cd = tex2D(_DarkTex, i.uv);
			    cd.rgb *= cd.a;
				return _FadeState*cl + (1.0f-_FadeState)*cd;
				//return float4(1.0,1.0,1.0,0.5);
			}
			
			ENDCG
		}
	} 
}
