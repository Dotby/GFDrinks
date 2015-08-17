Shader "Custom/depopFX" 
{
	Properties 
	{
		_MainTex ("Texture", 2D) = "white" {}
		_MainColor ("Color", color) = (1,1,1,0)
		_Noise ("Base (RGB)", 2D) = "white" {}
		_Threshold ("Threshold", Range (0, 1)) = 0.5
		_Bias ("Bias", Range (0, 0.07)) = 0.03
		_Origin ("Origin", Vector) = (0,0,0,0)
		_Range ("Range", float) = 1
	}
	
	SubShader 
	{
		Tags { "RenderType"="transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert
		#pragma target 3.0
		
		sampler2D _MainTex;
		sampler2D _Noise;
		float _Threshold;
		float _Bias;
		float4 _Origin;
		float _Range;
		float4 _MainColor;
		
		struct Input 
		{
			float2 uv_MainTex;
			float2 uv_Noise;
			float3 worldPos;
		};

		void surf (Input IN, inout SurfaceOutput o) 
		{
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			half4 alphaTex = tex2D (_Noise, IN.uv_Noise);
			
			o.Albedo = c.rgb;
			
			float d = _Threshold - (distance(IN.worldPos, _Origin.xyz) / _Range);
			
			if (alphaTex.r > d + _Bias)
				o.Alpha = 1;
			else if (alphaTex.r < d - _Bias)
				clip(-1);
			else
				o.Albedo = _MainColor;//o.Alpha = abs(alphaTex.r - (d - _Bias)) / (2 * _Bias);
		}
		ENDCG
	} 
	FallBack "Diffuse"
}