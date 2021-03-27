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
  const float colorChangeSpeed = 0.3;
  vec3 color = vec3(
    abs(sin(u_time * colorChangeSpeed+uv.x*uv.y)),
    abs(sin(u_time * colorChangeSpeed -TWO_PI/3.+uv.x*uv.y)),
    abs(sin(u_time * colorChangeSpeed -TWO_PI/1.5+uv.x*uv.y))
  );

  uv *= 50.;

  uv += vec2(u_time*3.);

  vec2 fuv = fract(uv);
  vec2 tuv = floor(uv);

  float flipX = rand(tuv.x * 50. + tuv.y);
  fuv.x = abs(step(.5,flipX) -fuv.x);

  color *= vec3(smoothstep(fuv.x-0.15,fuv.x-0.08,fuv.y) - smoothstep(fuv.x+0.08,fuv.x+0.15,fuv.y));
  gl_FragColor = vec4(color,1);
}