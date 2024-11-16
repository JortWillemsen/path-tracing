// See https://aka.ms/new-console-template for more information

using Engine;
using Renderer;

using Color = Engine.Vector3;

const float aspectRatio = 16f / 9f;

// Calculate image dimensions based on the aspect ratio
// TODO: ADD CHECK FOR INVALID DIMENSIONS
var imageWidth = 400;
var imageHeight = (int)(imageWidth / aspectRatio);


// Camera
var focalLength = 1f;
var viewportHeight = 2f;

var camera = new Camera(imageWidth, imageHeight, focalLength, Vector3.Zero());

var viewport = new Viewport(aspectRatio, viewportHeight, camera);

ImageBuilder.BuildToFile(viewport, "/output/image.ppm");

