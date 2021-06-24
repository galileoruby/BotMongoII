namespace BotMongoII.Models.Zip
{
    public class ZipMongoModel
    {         
        public string Id { get; set; }
      
        public string City { get; set; } 
        public string Zip { get; set; }         

        public ZipLocModel Loc { get; set; }
         
        public int Pop { get; set; } 
        public string State { get; set; }
    }
}
