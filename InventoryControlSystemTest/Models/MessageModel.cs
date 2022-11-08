using Newtonsoft.Json;

namespace InventoryControlSystemTest.Models
{
    public enum TypeMessage
    {
        Information,
        Error
    }
    public class MessageModel
    {
        public TypeMessage Type { get; set; }
        public string Text { get; set; }

        public MessageModel(string text, TypeMessage type = TypeMessage.Information)
        {
            this.Type = type;
            this.Text = text;
        }

        public static string Serialize (string message, TypeMessage type = TypeMessage.Information)
        {
            var messageModel = new MessageModel(message, type);
            return JsonConvert.SerializeObject(messageModel);
        }

        public static MessageModel Deserialize (string messageString)
        {
            return JsonConvert.DeserializeObject<MessageModel>(messageString);
        }
    }
}
