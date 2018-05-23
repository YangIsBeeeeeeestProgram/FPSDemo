// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/ReticleShader" {
	Properties{
		_Color("Main Color", Color) = (1, 1, 1, 1)
		_Cutoff("ReticleThickness", Range(0,0.9)) = .5
		_Glow("Glow Strength", Range(1,500)) = 100
		_MainTexture("ReticleShape", 2D) = "black"{}
	}

		SubShader{
		Tags{ "Queue" = "Geometry" "IgnoreProjector" = "True" "RenderType" = "TransparentCutout" }
		ZTest Always

		Stencil{
		Ref 1
		Comp Equal

	}



		// first pass:
		//   render any pixels that are more than [_Cutoff] opaque
		Pass{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

	struct appdata_t {
		float4 vertex : POSITION;
		float4 color : COLOR;
		float2 texcoord : TEXCOORD0;
	};

	struct v2f {
		float4 vertex : POSITION;
		float4 color : COLOR;
		float2 texcoord : TEXCOORD0;
	};

	sampler2D _MainTexture;
	float4 _MainTexture_ST;

	float _Cutoff;
	float _Glow;


	v2f vert(appdata_t v)
	{
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.color = v.color;
		o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTexture);
		return o;
	}

	float4 _Color;
	half4 frag(v2f i) : COLOR
	{
		float4 col = tex2D(_MainTexture,i.texcoord);
		clip(col.a - _Cutoff);
		return _Color*_Glow;
	}
		ENDCG
	}
	}

}
