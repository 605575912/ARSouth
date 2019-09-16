// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/CilpShader"
//Shader "Unlit/AlphaShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Texture", 2D) = "white" {}
        _Cutoff ("Alpha Cutoff", Range(0, 1)) = 0.5
	   _clip("clipZ",Float) = 0
	   _topVector("顶部向量",Vector)=(0,0,0,0)  
	   _topMaxVector("顶部向量",Vector)=(0,0,0,0)  
    }
    SubShader
    {
        // 透明度测试队列为AlphaTest，所以Queue=AlphaTest
        // RenderType标签让Unity把这个Shader归入提前定义的组中，以指明该Shader是一个使用了透明度测试的Shader
        // IgonreProjector为True表明此Shader不受投影器（Projectors）影响
        Tags { "Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="Transparent" }
      //  Tags { "RenderType"="Opaque" }
      //  Tags { "RenderType"="TransparentCutout" }
		//不关闭背面剔除的话看不到物体内侧
		//Cull off
		Lighting Off
		//ZWrite Off
        Pass
        {
            Tags { "LightMode"="ForwardBase" }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            struct a2v
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldNormal : TEXCOORD1;
                float3 worldPos : TEXCOORD2;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            // 用于决定调用clip函数时进行的透明度测试使用的判断条件
            fixed _Cutoff;
            float _clip;
			Vector _topVector;
			Vector _topMaxVector;
            v2f vert (a2v v)
            {
                v2f o;

                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);

                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                fixed3 worldNormal = normalize(i.worldNormal);
                fixed3 worldPos = normalize(i.worldPos);
                fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(worldPos));
                // 纹素值
                fixed4 texColor = tex2D(_MainTex, i.uv);
				
				// 原理
                // if ((texColor.a - _Cutoff) < 0.0) { discard; }
                // 如果结果小于0，将片元舍弃
               // clip(texColor.a - _Cutoff);

			   	if(_clip==1){
				 if(i.worldPos.y> _topVector.y&&i.worldPos.y> _topMaxVector.y&&i.worldPos.x> _topVector.x&&i.worldPos.x< _topMaxVector.x&&i.worldPos.z> _topVector.z&&i.worldPos.z< _topMaxVector.z){
				  discard;
				 }

				}
				return texColor;
                // 反射率
              //  fixed3 albedo =  texColor.rgb * _Color.rgb;
		
                // 环境光
               // fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb * albedo;
                // 漫反射
              //  fixed3 diffuse = _LightColor0.rgb * albedo * max(0, dot(worldNormal, worldLightDir));
              //  return fixed4(ambient + diffuse, 1.0);
            }
            ENDCG
        }
    }
}