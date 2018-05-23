Shader "Custom/OpticWallShader" {

	SubShader {
		Tags { "Queue" = "Background" }
	Lighting Off
		ZTest Always
		ZWrite Off

	 ColorMask 0
	     
	 Pass {
	     Stencil {
	         Ref 5
                Comp Always
                Pass Replace
			
                
                
	     }
	 }
			
		} 
	}
