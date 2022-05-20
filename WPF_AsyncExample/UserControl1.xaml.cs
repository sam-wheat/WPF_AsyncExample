namespace WPF_AsyncExample;

public partial class UserControl1 : UserControl
{
    private ILifetimeScope container;

    public UserControl1(ILifetimeScope container)
    {
        this.container = container;
        InitializeComponent();
    }

    

    public async Task Initialize()
    {
        await Task.Delay(1000);
        using (ILifetimeScope scope = container.BeginLifetimeScope())
        {
            UserControl2 userControl2 = scope.Resolve<UserControl2>();
            await userControl2.Initialize();
        }
    }
}
