namespace JFAppMaui
{
    public partial class JFApp : Application
    {
        public JFApp()
        {
            InitializeComponent();

            MainPage = new JFAppShell();
        }
    }
}
