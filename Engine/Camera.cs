namespace Engine;

public class Camera
{
    public float FocalLength { get; private set; }
    public int ImageWidth { get; private set; }
    public int ImageHeight { get; private set; }
    public Vector3 Location { get; private set; }

    public Camera(
        int imageWidth,
        int imageHeight,
        float focalLength, 
        Vector3 location)
    {
        ImageWidth = imageWidth;
        ImageHeight = imageHeight;
        FocalLength = focalLength;
        Location = location;
    }
}