using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway_Reservation.Models
{
    public class TrainDetails
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Train_Id { get; set; }
        public string TrainName { get;set; }
        public string SourceStation { get; set; }
        public string DestinationStation { get; set; }
        public int Fare { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set;}
        public int TotalSeats { get; set;}
    }
}