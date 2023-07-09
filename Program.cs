
int maxWidth = int.Parse(args[1]);
int maxHeight = int.Parse(args[2]);

foreach (var file in Directory.GetFiles(args[0]))
{
    try
    {
        using var img = Image.Load(file);

        double ratioX = maxWidth / (double)img.Width;
        double ratioY = maxHeight / (double)img.Height;
        double ratio = Math.Min(ratioX, ratioY);

        var newWidth = (int)(img.Width * ratio);
        var newHeight = (int)(img.Height * ratio);

        img.Mutate(x => x.Resize(newWidth, newHeight));

        await img.SaveAsJpegAsync(file);

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
