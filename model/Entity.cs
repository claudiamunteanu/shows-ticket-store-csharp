using System;

namespace app.model
{
    [Serializable]
    public class Entity<TID>
    {
        public TID Id { get; set; }
    }
}
