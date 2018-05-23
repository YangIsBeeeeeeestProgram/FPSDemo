Shader "Custom/PKA-Forward" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_MetallicTex("Metallic", 2D) = "white" {}
		_Normal("NormalMap",2D) = "bump" {}
	}
	SubShader {
		Tags{ "RenderType" = "Transparent" }
		LOD 200
		Stencil {
		 	Ref 1
		 	Comp NotEqual
		 	
		}
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _MetallicTex;
		sampler2D _Normal;

		struct Input {
			float2 uv_MainTex;
		};

		fixed4 _Color;
		
	

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			fixed4 m = tex2D(_MetallicTex, IN.uv_MainTex);
			fixed3 n = UnpackNormal (tex2D (_Normal, IN.uv_MainTex)); 
			o.Albedo = c.rgb;
			o.Normal = n;
			o.Occlusion = m.g;
			// Metallic and smoothness come from slider variables
			o.Metallic = m.r;
			o.Smoothness = m.a;
			o.Alpha = 0;
		}
		ENDCG
		}

	FallBack "Diffuse"
}
