// whitebalance.fs
//
// White Balance tone mapping: map [0,max] -> [0,1]
// for a local maximum "max" set externally

uniform sampler2D sampler0;
uniform vec3 max;

void main(void)
{
    vec4 sample = texture2D(sampler0, 
                            gl_TexCoord[0].st);

    // scale color channels differently
    // based on each channel's max
    gl_FragColor.rgb = sample.rgb / max;
    gl_FragColor.a = 1.0;
}
