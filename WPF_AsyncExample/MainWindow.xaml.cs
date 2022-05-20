namespace WPF_AsyncExample;

public partial class MainWindow : Window
{
    private Func<UserControl1> userControl1Factory;

    public MainWindow(Func<UserControl1> userControl1Factory)
    {
        InitializeComponent();
        Button1.Loaded += Button1_Loaded;
        this.userControl1Factory = userControl1Factory;
    }

    public async Task Initialize()
    {
        await Task.Delay(1000);
    }

    private async void Button1_Loaded(object sender, RoutedEventArgs e)
    {
        await Task.Delay(1000);
        UserControl1 userControl1 = userControl1Factory();
        await userControl1.Initialize();
    }
}
