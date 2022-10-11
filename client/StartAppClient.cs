using app.services;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using app.client.forms;

namespace app.client
{
    class StartAppClient
    {
        [DllImport( "kernel32.dll" )]
        static extern bool AttachConsole( int dwProcessId );
        private const int ATTACH_PARENT_PROCESS = -1;
        
        [STAThread]
        static void InitWindow()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
        
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        static void Main(string[] args)
        {
            AttachConsole( ATTACH_PARENT_PROCESS );

            InitWindow();

            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
            IDictionary props = new Hashtable();

            props["port"] = 0;
            TcpChannel channel = new TcpChannel(props, clientProv, serverProv);
            ChannelServices.RegisterChannel(channel, false);
            IAppServices services =
                (IAppServices) Activator.GetObject(typeof(IAppServices), "tcp://localhost:55555/App");
            
            Console.WriteLine("am obtinut referinta!!!");
            
            AppClientController controller = new AppClientController(services);
            MainWindow mainWindow = new MainWindow(controller);
            Application.Run(mainWindow);
        }
    }
}
