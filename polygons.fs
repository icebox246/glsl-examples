#ifdef GL_ES
precision mediump float;
#endif

#define PI 3.14159265359
#define TWO_PI 6.28318530718

uniform float u_time;
uniform vec2 u_resolution;

float rand(float n){return fract(sin(n) * 43758.5453123);}

void main() {
  vec2 uv = gl_FragCoord.xy / u_resolution;
  vec3 color = vec3(0.0);

  uv *= 3.;
  uv = fract(uv);

  float N = 5.;

  vec2 pos = uv- vec2(0.5);
  float r = length(pos) * 2.;
  float a = atan(pos.x,pos.y) + PI;


  float d = cos(PI/N)/cos(a-TWO_PI/N*floor((N * a + PI)/TWO_PI));

  color = vec3(1.) - step(d,r) * vec3(1.);

  gl_FragColor = vec4(color, 1);
}