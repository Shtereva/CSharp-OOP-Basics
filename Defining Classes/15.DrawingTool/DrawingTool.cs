public class DrawingTool
{
    private Shape tool;

    public DrawingTool(Shape tool)
    {
        this.tool = tool;
    }

    public Shape Tool => this.tool;
}
