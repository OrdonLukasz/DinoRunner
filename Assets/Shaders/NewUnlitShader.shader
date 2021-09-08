Shader "Unlit/NewUnlitShader"
{
    Properties{
    _Angle("Angle", Range(0, 3.14159265358979)) = 1
    _ArtifactCorrection("Artifact Correction", Float) = 1
    _Color("Main Color (A=Opacity)", Color) = (.5,.5,.5, 1)
    _MainTex("RGBA Texture  UV Transform)", 2D) = ""
    }

        SubShader{
            Tags {"Queue" = "Overlay"}
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            Pass {
                GLSLPROGRAM
                varying mediump vec3 rotation;
                varying mediump vec2 uv, negative1to1;

                #ifdef VERTEX
                uniform mediump mat4 _Object2World;
                uniform mediump vec4 _MainTex_ST;
                uniform mediump float _Angle, _ArtifactCorrection;
                void main() {
                    gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
                    uv = gl_MultiTexCoord0.xy;
                    negative1to1 = gl_MultiTexCoord0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                    rotation.xy = vec2(sin(_Angle), cos(_Angle));
                    rotation.z = rotation.y;
                    rotation.xy *= _ArtifactCorrection;
                }
                #endif

                #ifdef FRAGMENT
                uniform lowp sampler2D _MainTex;
                uniform lowp vec4 _Color;
                void main() {
                    lowp vec4 fragColor = texture2D(_MainTex, uv) * _Color;
                    fragColor.a *= float(
                        dot(normalize(negative1to1), rotation.xy) < rotation.z
                    );
                    gl_FragColor = fragColor;
                }
                #endif     
                ENDGLSL
            }
    }

}
