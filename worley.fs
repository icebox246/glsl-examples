#ifdef GL_ES
precision mediump float;
#endif

#define PI 3.14

uniform float u_time;
uniform vec2 u_resolution;

float rand(float n){return fract(sin(n) * 43758.5453123);}

void main() {
  vec2 uv = gl_FragCoord.xy / u_resolution;
  vec3 color = vec3(0.0);
  float lamda = 0.05;
  float d1 = 93102801.0;
  const float pC = 100.0;
  for (float i = 0.0; i < pC; i++) {
    vec2 p = vec2(rand(i),rand(i+3219381.0));
    d1 = min(distance(uv, p),d1);
  }

  float d=clamp(d1*10.0,0.0,1.0);

  color = vec3(d);

  gl_FragColor = vec4(color, 1);
}