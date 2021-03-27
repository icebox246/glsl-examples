#ifdef GL_ES
precision mediump float;
#endif

#define PI 3.14

uniform float u_time;
uniform vec2 u_resolution;


float sqr(float x) {
  return x * x;
}

float isqr(float x) {
  return 1.0 - sqr(x);
}

float dist(float x, float y) {
  return abs(x-y);
}

void main() {
  vec2 uv = gl_FragCoord.xy / u_resolution;

  float off = uv.x;

  vec4 color = vec4(
    sqr(1.0 - smoothstep(0.0,1.0,off)),
    sqr(smoothstep(-0.5,0.5,off)- smoothstep(0.5,1.5,off)),
    sqr(smoothstep(0.0,1.0,off)),
    1
  );

  color *= isqr(1.0-uv.y);

  gl_FragColor = color;
}