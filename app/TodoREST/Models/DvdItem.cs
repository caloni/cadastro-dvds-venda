namespace TodoREST.Models
{
    public class DvdItem
    {
        public string id { get; set; }
        public string productTitle { get; set; }
        public string images { get; set; }
        public int qty { get; set; } = 1;
        public string price { get; set; }
        public string condition { get; set; } = "Usado";
        public string movieTrailer { get; set; } = "Mercado Envios";
        public string delivery { get; set; } = "Por conta do comprador";
        public string takeout { get; set; } = "Concordo";
        public string warranty { get; set; } = "Garantia do vendedor";
        public string movieFormat { get; set; } = "DVD";
        public string movieTitle { get; set; }
        public string movieDirector { get; set; }
        public string resolution { get; set; } = "SD";
        public int disks { get; set; } = 1;
        public string audio { get; set; } = "Inglês";
        public string gender { get; set; } = "Drama";
        public string company { get; set; }
        public string format { get; set; } = "Físico";
    }
}
