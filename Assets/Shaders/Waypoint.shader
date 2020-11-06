Shader "Custom/Waypoint"
{

    Properties
    {
        [Enum(Equal, 3, NotEqual, 6)] _StencilTest ("Stencil Test", int) = 3
    }
    SubShader
    {
        ColorMask 0

        Stencil {
            Ref 0
        }

        Pass
        {
        }
    }
}
