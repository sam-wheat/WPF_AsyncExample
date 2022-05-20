namespace WPF_AsyncExample;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e) => OnStartupAsync(e).Wait(); // Deadlock
    // protected override void OnStartup(StartupEventArgs e) => Task.Run(async () => await OnStartupAsync(e)).Wait();
    // protected override void OnStartup(StartupEventArgs e) => Dispatcher.InvokeAsync(async () => await OnStartupAsync(e)).Wait();
    // Need a turtle here.  

    protected async Task OnStartupAsync(StartupEventArgs e)
    {
        base.OnStartup(e);

        try
        {
            IHost host = CreateHostBuilder(e.Args).Build();
            using (ILifetimeScope scope = host.Services.GetAutofacRoot())
            {
                MainWindow mainWindow = scope.Resolve<MainWindow>();
                await mainWindow.Initialize();
                mainWindow.Show(); 
            }
        }
        catch (Exception ex)
        {
            string y = ex.ToString();
        }
    }


    public IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>((hostBuilder, builder) => ConfigureContainer(hostBuilder.Configuration, builder));

    protected void ConfigureContainer(IConfiguration config, ContainerBuilder builder)
    {
        builder.RegisterType<MainWindow>().SingleInstance();
        builder.RegisterType<MainWindowViewModel>().SingleInstance();
        builder.RegisterType<UserControl1>();
        builder.RegisterType<UserControl2>();
    }
}
