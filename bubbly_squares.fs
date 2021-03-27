#ifdef GL_ES
precision mediump float;
#endif

#define PI 3.14

uniform float u_time;
uniform vec2 u_resolution;

void square(vec2 uv, vec2 pos, vec2 size, out vec3 color, float rad) {
  float pl = pos.x;
  float pb = pos.y;
  float pr = 1.0 - pos.x - size.x;
  float pt = 1.0 - pos.y - size.y;

  float l = smoothstep(pl - rad, pl + rad, uv.x);
  float b = smoothstep(pb - rad, pb + rad, uv.y);
  float r = smoothstep(pr - rad, pr + rad, 1.0 - uv.x);
  float t = smoothstep(pt - rad, pt + rad, 1.0 - uv.y);

  color += vec3(step(0.5, l * b * r * t));
}

void ssquare(vec2 uv, vec2 pos, vec2 size, out vec3 color, float width, float rad) {
  float pl = pos.x;
  float pb = pos.y;
  float pr = 1.0 - pos.x - size.x;
  float pt = 1.0 - pos.y - size.y;

  float l = smoothstep(pl - rad, pl + rad, uv.x);
  float b = smoothstep(pb - rad, pb + rad, uv.y);
  float r = smoothstep(pr - rad, pr + rad, 1.0 - uv.x);
  float t = smoothstep(pt - rad, pt + rad, 1.0 - uv.y);

  float w=width * 0.5;
  float irad = max(0.0,rad-w);
  float il = (smoothstep(pl + w - irad, pl + w + irad, uv.x));
  float ib = (smoothstep(pb + w - irad, pb + w + irad, uv.y));
  float ir = (smoothstep(pr + w - irad, pr + w + irad, 1.0 - uv.x));
  float it = (smoothstep(pt + w - irad, pt + w + irad, 1.0 - uv.y));

  color = max(vec3(step(0.5,(l * b * r * t)) - step(0.5,il*ib*ir*it)),color);
}

float rand(float n){return fract(sin(n) * 43758.5453123);}

void main() {
  vec2 uv = gl_FragCoord.xy / u_resolution;
  vec3 color = vec3(0.0);

  for(float i = 0.0; i < 15.0; i++) {
    vec2 size = vec2(rand(i) * 0.2+ 0.05);
    float speed = size.x * rand(i + 72.8214) + 0.01;
    ssquare(uv,vec2(i/15.0-.1,mod((u_time + 3289.8) *speed,1.0 + size.x)-size.x),size,color,0.02,0.05);
  }

  color *= mix(vec3(153, 15, 252), vec3(252, 15, 102), uv.y * uv.y) / 256.0;

  gl_FragColor = vec4(color, 1);
}