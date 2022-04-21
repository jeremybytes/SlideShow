using ImageLibrary;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SlideShow;

public partial class MainWindow : Window
{
    private List<string> images = new();
    private int currentIndex = 0;
    private readonly DispatcherTimer timer;

    public MainWindow()
    {
        InitializeComponent();

        timer = new DispatcherTimer
        {
            Interval = new System.TimeSpan(0, 0, 10)
        };
        timer.Tick += (s, e) => ShowNextImage();

        Loaded += (s, e) =>
        {
            var location = @"C:\Users\jerem\Pictures\Idle Album";

            // Uncomment this section if you want a folder dialog;
            // otherwise, manually set the 'location' above.
            var dlg = new FolderBrowserDialog { SelectedPath = location };
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               location = dlg.SelectedPath;
            }

            images = ImageLocator.GetImagesFromLocation(location);
            images.Shuffle();
            ShowImage(0);
            timer.Start();
        };
    }

    private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Space:
                Pause();
                break;
            case Key.Next:
            case Key.Right:
            case Key.Enter:
                ShowNextImage();
                break;
            case Key.Left:
            case Key.PageUp:
                ShowPreviousImage();
                break;
            case Key.Escape:
                Close();
                break;
            default:
                break;
        }
    }

    private void Pause()
    {
        if (timer.IsEnabled)
            timer.Stop();
        else
            timer.Start();
    }

    private void ShowImage(int index)
    {
        var image = Image.FromFile(images[index]) as Bitmap;
        var imageSource = image?.ToWpfBitmap();
        targetImage.Source = imageSource;
    }

    private void ShowNextImage()
    {
        currentIndex++;
        if (currentIndex >= images.Count) currentIndex = 0;
        ShowImage(currentIndex);
    }

    private void ShowPreviousImage()
    {
        if (currentIndex > 0) currentIndex--;
        ShowImage(currentIndex);
    }
}
