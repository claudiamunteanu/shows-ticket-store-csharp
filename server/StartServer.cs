using System;
using System.Collections;
using app.persistence;
using app.persistence.interfaces;
using app.server.validators;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Hashtable=System.Collections.Hashtable;

namespace app
{
    
    using server;
    
    class StartServer
    {
        static void Main(string[] args)
        {
            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
            IDictionary props = new Hashtable();

            props["port"] = 55555;
            TcpChannel channel = new TcpChannel(props, clientProv, serverProv);
            ChannelServices.RegisterChannel(channel, false);

            IShowRepository showRepository = new ShowsDBRepository();
            ITicketRepository ticketRepository = new TicketsDBRepository();
            IUserRepository userRepository = new UsersDBRepository();
            UserValidator userValidator = new UserValidator();
            TicketValidator ticketValidator = new TicketValidator();
            var server = new AppService(showRepository, ticketRepository, userRepository, userValidator, ticketValidator);
            RemotingServices.Marshal(server, "App");
            
            Console.WriteLine("Server started ...");
            Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();

        }
    }
}
