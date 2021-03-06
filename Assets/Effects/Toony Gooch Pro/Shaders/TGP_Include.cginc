// Toony Gooch Pro+Mobile Shaders
// (c) 2013, Jean Moreno

#ifndef TOONYGOOCH_INCLUDED
	#define TOONYGOOCH_INCLUDED
	
	//Lighting Ramp
	sampler2D _Ramp;
	
	//Highlight/Shadow Colors
	fixed4 _Color;
	fixed4 _SColor;
	
#endif

// TOONY GOOCH
#pragma lighting ToonRamp exclude_path:prepass
inline half4 LightingToonyGooch (SurfaceOutput s, half3 lightDir, half atten)
{
	#ifndef USING_DIRECTIONAL_LIGHT
		lightDir = normalize(lightDir);
	#endif
	
	//Ramp shading
	fixed ndl = dot(s.Normal, lightDir)*0.5 + 0.5;
	fixed3 ramp = tex2D(_Ramp, fixed2(ndl,ndl));
	
	//Gooch shading
	ramp = lerp(_SColor,_Color,ramp);
	
	fixed4 c;
	c.rgb = s.Albedo * _LightColor0.rgb * ramp * (atten * 2);
	c.a = 0;
	
	return c;
}

// TOONY GOOCH + SPECULAR
#pragma lighting ToonRamp exclude_path:prepass
inline half4 LightingToonyGoochSpec (SurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
{
	#ifndef USING_DIRECTIONAL_LIGHT
		lightDir = normalize(lightDir);
	#endif
	
	//Ramp shading
	fixed ndl = dot(s.Normal, lightDir)*0.5 + 0.5;
	fixed3 ramp = tex2D(_Ramp, fixed2(ndl,ndl));
	
	//Gooch shading
	ramp = lerp(_SColor,_Color,ramp);
	
	//Specular
	half3 h = normalize(lightDir + viewDir);
	float ndh = max (0, dot (s.Normal, h));
	float spec = pow (ndh, s.Specular*128.0) * s.Gloss;
	
	fixed4 c;
	c.rgb = s.Albedo * _LightColor0.rgb * ramp * (atten * 2) + (spec * _SpecColor);
	c.a = 0;
	
	return c;
}