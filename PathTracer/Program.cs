// See https://aka.ms/new-console-template for more information

using PathTracer;

const int imageWidth = 256;
const int imageHeight = 256;

ImageBuilder.BuildToFile(imageWidth, imageHeight, "/output/image.ppm");
