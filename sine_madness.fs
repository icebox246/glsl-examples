#ifdef GL_ES
precision mediump float;
#endif

#define PI 3.14

uniform float u_time;
uniform vec2 u_resolution;

void main() {
  vec4 color = vec4(1,1,1,1);
  vec2 uv = gl_FragCoord.xy / u_resolution;
  float lineWidth = 0.005;
  const float sineCount = 10.0;

  for(float i = 1.0; i <= sineCount; i++) {
    float amp = i* 0.1 *0.8;
    float off = (sin((uv.x-u_time*0.05 * i)*PI*2.0)+1.0)*0.5 *amp + (1.0-amp)*0.5;
    float val = step(off - lineWidth/2.0 * i,uv.y) - step(off + lineWidth/2.0 * i,uv.y);
    color.x -= val / sineCount * i;
    color.y -= val / sineCount * i * i * 0.1;
  }

  gl_FragColor = color;
}