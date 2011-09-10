// iris.fs
//
// Iris tone mapping: map [0,max] -> [0,1]
// for a local maximum "max" set externally

uniform sampler2D sampler0;
uniform vec3 max;

void main(void)
{
    vec4 sample = texture2D(sampler0, 
                            gl_TexCoord[0].st);

    // scale all color channels evenly
    float maxMax = (max.r > max.g) ? max.r : max.g;
    maxMax = (maxMax > max.b) ? maxMax : max.b;

    gl_FragColor.rgb = sample.rgb / maxMax;
    gl_FragColor.a = 1.0;
}
