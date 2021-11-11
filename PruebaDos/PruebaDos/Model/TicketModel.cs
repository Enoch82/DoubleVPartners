using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaDos.Model
{
    [Table(name: "Ticket")]
    public class TicketModel
    {
        [Key]
        public int ticketId { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string usuario { get; set; }

        public DateTime fechaCreacion { get; set; }

        public DateTime fechaActualizacion { get; set; }

        public bool estatus { get; set; }

    }
}
