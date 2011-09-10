// texspec.vs
//
// Generic vertex transformation,
// compute diffuse lighting,
// put N.H into a texcoord
// for use by 1D pow tex lookup

uniform vec3 lightPos[1];

void main(void)
{
    // normal MVP transform
    gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;

    vec3 N = normalize(gl_NormalMatrix * gl_Normal);
    vec4 V = gl_ModelViewMatrix * gl_Vertex;
    vec3 L = normalize(lightPos[0] - V.xyz);
    vec3 H = normalize(L + vec3(0.0, 0.0, 1.0));

    // put diffuse lighting result in primary color
    float NdotL = max(0.0, dot(N, L));
    gl_FrontColor = gl_Color * vec4(NdotL);

    // copy (N.H)*8-7 into texcoord if N.L is positive
    float NdotH = 0.0;
    if (NdotL > 0.0)
        NdotH = max(0.0, dot(N, H) * 8.0 - 7.0);
    gl_TexCoord[0] = vec4(NdotH, 0.0, 0.0, 1.0);
}
