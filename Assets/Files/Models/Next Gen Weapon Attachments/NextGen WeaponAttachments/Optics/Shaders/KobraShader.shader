Shader "Custom/Kobra-Forward" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Normal("NormalMap",2D) = "bump" {}
		_Metallic("Metallic", 2D) = "white" {}
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200
		Stencil{
		Ref 1
		Comp Always

	}
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0

		sampler2D _MainTex;
	sampler2D _Normal;
	sampler2D _Metallic;

	struct Input {
		float2 uv_MainTex;
	};


	fixed4 _Color;



	void surf(Input IN, inout SurfaceOutputStandard o) {
		// Albedo comes from a texture tinted by color
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
		fixed3 n = UnpackNormal(tex2D(_Normal, IN.uv_MainTex));
		fixed4 m = tex2D(_Metallic, IN.uv_MainTex);
		o.Albedo = c.rgb;
		o.Normal = n;
		o.Occlusion = m.g;
		// Metallic and smoothness come from slider variables
		o.Metallic = m.r;
		o.Smoothness = m.a;
		o.Alpha = c.a;
	}
	ENDCG
	}

		
}
