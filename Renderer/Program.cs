// See https://aka.ms/new-console-template for more information

using Renderer;

const float aspectRatio = 16f / 9f;

// Calculate image dimensions based on the aspect ratio
// TODO: ADD CHECK FOR INVALID DIMENSIONS
var imageWidth = 400;
var imageHeight = (int)(imageWidth / aspectRatio);

float viewportHeight = 2f;
float viewportWidth = viewportHeight * ((float) imageWidth / imageHeight);

ImageBuilder.BuildToFile(imageWidth, imageHeight, "/output/image.ppm");
