Shader "Custom/Plain_Stencil"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags {"Queue" = "Geometry" "RenderType"="Opaque" }
        LOD 100
        ZWrite Off
        ColorMask 0
        Stencil{
            Ref 2
            Comp always
            Pass replace
        }

        Pass
        {
          
        }
    }
}
