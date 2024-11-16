// See https://aka.ms/new-console-template for more information

using Engine;
using Engine.Geometry;
using Renderer;

using Color = Engine.Vector3;

const float aspectRatio = 16f / 9f;

// Calculate image dimensions based on the aspect ratio
// TODO: ADD CHECK FOR INVALID DIMENSIONS
var imageWidth = 400;
var imageHeight = (int)(imageWidth / aspectRatio);
var maxDepth = 50;
var samples = 100;

// Camera
var focalLength = 1f;
var viewportHeight = 2f;

var camera = new Camera(aspectRatio, focalLength, imageWidth, imageHeight, maxDepth, samples,Vector3.Zero());

var sphere1 = new Sphere(new Vector3(0f, 0f, -1f), 0.5f);
var sphere2 = new Sphere(new Vector3(0f, -50.5f, -1f), 50f);

var scene = new Scene(sphere1, sphere2);

ImageRenderer.RenderToFile(camera, scene, "/output/" + args[0]);

