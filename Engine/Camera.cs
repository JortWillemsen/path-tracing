namespace Engine;

public class Camera
{
    public float FocalLength { get; private set; } 
    public float AspectRatio { get; private set; }
    public int ImageWidth { get; private set; }
    public int ImageHeight { get; private set; }
    
    public float ViewportWidth { get; private set; }
    public float ViewportHeight { get; private set; }
    
    public Vector3 Origin { get; private set; }
    public Vector3 U { get; private set; }
    public Vector3 V { get; private set; }
    
    public Camera(float aspectRatio, float focalLength, int imageWidth, int imageHeight, Vector3 origin)
    {
        AspectRatio = aspectRatio;
        FocalLength = focalLength;
        ImageWidth = imageWidth;
        ImageHeight = imageHeight;
        Origin = origin;
        
        ViewportWidth = 2f * ((float) ImageWidth /  ImageHeight);
        ViewportHeight = 2f;
        
        U = new Vector3(ViewportWidth, 0f, 0f);
        V = new Vector3(0f, -ViewportHeight, 0f);
    }
    
    public Vector3 PixelDeltaU => U / ImageWidth;
    public Vector3 PixelDeltaV => V / ImageHeight;
    
    public Vector3 UpperLeft => Origin - new Vector3(0f, 0f, FocalLength) - U / 2 - V / 2;

    public Vector3 Pixel0 => UpperLeft + .5f * (PixelDeltaU + PixelDeltaV);
}