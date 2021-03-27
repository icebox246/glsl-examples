const canvases = document.querySelectorAll(".myGlslCanvas");
canvases.forEach(canvas => {
  new GlslCanvas(canvas);
})