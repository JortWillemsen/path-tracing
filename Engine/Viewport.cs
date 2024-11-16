namespace Engine;

public class Viewport
{
    public float AspectRatio { get; private set; }
    
    public float Width { get; private set; }
    public float Height { get; private set; }
    
    public Vector3 U { get; private set; }
    public Vector3 V { get; private set; }

    public Camera Cam { get; private set; }
    
    public Viewport(float aspectRatio, float height, Camera camera)
    {
        AspectRatio = aspectRatio;
        Cam = camera;
        Width = height * ((float)camera.ImageWidth / camera.ImageHeight);
        Height = height;
        
        U = new Vector3(Width, 0f, 0f);
        V = new Vector3(0f, -height, 0f);
    }
    
    public Vector3 PixelDeltaU => U / Cam.ImageWidth;
    public Vector3 PixelDeltaV => V / Cam.ImageHeight;
    
    public Vector3 UpperLeft => Cam.Location - new Vector3(0f, 0f, Cam.FocalLength) - U / 2 - V / 2;

    public Vector3 Pixel0 => UpperLeft + .5f * (PixelDeltaU + PixelDeltaV);
}