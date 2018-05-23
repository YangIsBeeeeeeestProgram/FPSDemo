Shader "Custom/OpticLensShader" {

	SubShader{
		Tags{ "Queue" = "Background" }
		Lighting Off
		ZTest Always
		ZWrite Off

		ColorMask 0

		Pass{
		Stencil{
		Ref 1
		CompFront greater
		Pass Replace



	}
	}

	}
}
