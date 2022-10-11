using System;

namespace app.client
{
    public enum AppUserEvent
    {
        TicketBought
    };
    public class AppUserEventArgs : EventArgs
    {
        private readonly AppUserEvent userEvent;
        private readonly Object data;

        public AppUserEventArgs(AppUserEvent userEvent, object data)
        {
            this.userEvent = userEvent;
            this.data = data;
        }

        public AppUserEvent UserEventType
        {
            get { return userEvent; }
        }

        public object Data
        {
            get { return data; }
        }
    }
}
