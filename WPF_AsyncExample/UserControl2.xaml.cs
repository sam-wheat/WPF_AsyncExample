namespace WPF_AsyncExample;

public partial class UserControl2 : UserControl
{
    public UserControl2()
    {
        InitializeComponent();
    }

    public async Task Initialize()
    {
        await Task.Delay(1000);
        bool success = true; // goal is to get here.
    }
}
