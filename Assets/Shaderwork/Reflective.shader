Shader "Custom/Reflective" {
    Properties {
        _NoiseTex ("Noise", 2D) = "white" {}
        _NoiseSpeed("Noise Speed", Range(0,10)) = 0.75
        _Tint("Color Tint", Color) = (1,0,0,0)
        _Cube("Reflection Map", Cube) = "" {}
        _FlowSpeed("Flow Speed", Range(0,10)) = 8
        _FadeNoiseValue("Fade Noise Value", Range(0,10)) = 2
    }
    SubShader {
        Pass {   
            CGPROGRAM
    
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"

            // User-specified uniforms
            uniform samplerCUBE _Cube;
            fixed4 _Tint;
            fixed _FlowSpeed;
            fixed _FadeNoiseValue;
            fixed _NoiseSpeed;
            sampler2D _NoiseTex;

            struct vertexInput {
               float4 vertex : POSITION;
               float3 normal : NORMAL;
            };
            struct vertexOutput {
               float4 pos : SV_POSITION;
               float3 normalDir : TEXCOORD1;
               float3 viewDir : TEXCOORD2;
            };
    
            vertexOutput vert(vertexInput input) 
            {
               vertexOutput output;
   
               float4x4 modelMatrix = unity_ObjectToWorld;
               float4x4 modelMatrixInverse = unity_WorldToObject; 
   
               output.viewDir = mul(modelMatrix, input.vertex).xyz - _WorldSpaceCameraPos;
               output.normalDir = normalize(mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);
               
               output.pos = UnityObjectToClipPos(input.vertex);
               return output;
            }

            float4 frag(vertexOutput input) : COLOR
            {
               float4 noise = tex2D (_NoiseTex, (float2(input.normalDir.z, input.normalDir.x) + (_Time.y * _NoiseSpeed))%1);// (float2 (input.normalDir.z + (_NoiseSpeed), input.normalDir.x + (_NoiseSpeed)))%1 * _NoisePower);
               
               float3 reflectedDir = reflect(input.viewDir + noise * sin(_Time.y * _FlowSpeed), normalize(input.normalDir));

               float4 ret = lerp (texCUBE(_Cube, reflectedDir), _Tint * noise, pow(abs(input.normalDir.y), _FadeNoiseValue));

               return ret;
            }
    
            ENDCG
        }
    }
}