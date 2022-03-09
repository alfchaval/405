Shader "Custom/DisolverAlpha" {
	Properties{ 
		_Color("Main Color", COLOR) = (1,1,1,1)
        _MainTex("Albedo Primary (RGB) Alpha(A)", 2D) = "white"
		//_SecondTex("Albedo Second (RGB)", 2D) = "white" {}
        _DissolverTex("Dissolver Tex (RGB)", 2D) = "white" {}
        //_Glossiness("Smoothness", Range(0,1)) = 0.5
        //_Metallic("Metallic", Range(0,1)) = 0.0
		_Emission("Emission", float) = 0
		[HDR] _EmissionColor("Color", Color) = (0,0,0)
        _DissolvePercentage("DissolvePercentage", Range(0,1)) = 0.0
       
    }
        SubShader{
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 200
        ZWrite off
        Blend SrcAlpha OneMinusSrcAlpha

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert alpha
        #pragma surface surf Lambert
 
                // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0
 
        sampler2D _MainTex;
		//sampler2D _SecondTex;
        sampler2D _DissolverTex;
 
    struct Input 
    {
        float2 uv_MainTex;
		//float2 uv_SecondTex;
        float2 uv_DissolverTex;
    };
 
    //half _Glossiness;
    //half _Metallic;
    half _DissolvePercentage;   
    fixed4 _Color;
	float _Emission;
 
    void surf(Input IN, inout SurfaceOutput o)
    {       
        // Albedo comes from a texture tinted by color
        fixed4 mainCol = tex2D (_MainTex, IN.uv_MainTex);
		//fixed4 secondCol = tex2D (_SecondTex, IN.uv_SecondTex);
        half gradient = tex2D(_DissolverTex, IN.uv_DissolverTex).r;       
        clip(gradient- _DissolvePercentage);
 
        //fixed4 c = lerp(1, gradient, 0) * secondCol.r;
		fixed4 c = lerp(gradient.r, mainCol.g ,  gradient);

        o.Albedo = mainCol.rgb;
		o.Emission = mainCol.rgb * tex2D(_MainTex, IN.uv_MainTex).a;
        // Metallic and smoothness come from slider variables
        //o.Metallic = _Metallic;
        //o.Smoothness = _Glossiness;        
        o.Alpha = tex2D (_MainTex, IN.uv_MainTex).a;
    }
    ENDCG
    }
    FallBack "Diffuse"
}
