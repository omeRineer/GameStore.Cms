namespace GameStore.Cms.Models.SignalR
{
    public class ReceiveSubscriberStateModel
    {
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public bool IsConnected { get; set; }
    }
}
