#ifdef GL_ES
precision mediump float;
#endif

#define PI 3.14159265359
#define TWO_PI 6.28318530718

uniform float u_time;
uniform vec2 u_resolution;
uniform vec2 u_mouse;

float rand2 (in vec2 st) {
    return fract(sin(dot(st.xy,
                         vec2(12.9898,78.233)))
                 * 43758.5453123);
}

float rand(float n){return fract(sin(n) * 43758.5453123);}

float noise(float n){
  float i = floor(n);
  float f = fract(n);
  return mix(rand(i),rand(i+1.),smoothstep(0.,1.,f));
}

float noise2(in vec2 n){
  vec2 i = floor(n);
  vec2 f = fract(n);

  float a = rand2(i);
  float b = rand2(i + vec2(1.,0.));
  float c = rand2(i + vec2(0.,1.));
  float d = rand2(i + vec2(1.,1.));

  vec2 u = f * f * (3. - 2. *f);
  return mix(a, b, u.x) +
   (c - a) * u.y * (1. - u.x) +
    ( d-b) * u.x* u.y;
}


void main() {
  vec2 uv = gl_FragCoord.xy / u_resolution;
  vec3 color = vec3(1);

  vec2 pos = uv - vec2(0.5);
  vec2 cPos = normalize(pos);
  float r = length(pos);

  float d = noise2(cPos*1. + vec2(u_time,sin(u_time)*2.)) *0.2 + .1;

  color *= smoothstep(d,d+0.015,r);

  gl_FragColor = vec4(color,1);
}