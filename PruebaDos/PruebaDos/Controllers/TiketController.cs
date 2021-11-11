using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using PruebaDos.Repository;
using PruebaDos.Model;
using System.Net;
using System.Net.Http;

namespace PruebaDos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TiketController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TiketController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("[action]")]
        public List<TicketModel> ObtenerTikets()
        {
            // var clienteModel = _unitOfWork.Cliente.ObtenerTodos();

            List<TicketModel> listaTickets = _unitOfWork.Tiket.ObtenerTodos().ToList();

            return listaTickets;
        }

        [HttpPatch("[action]")]
        public CustomResponse ActualizarTicket([FromBody] TicketModel tiket)
        {
            CustomResponse cr = new CustomResponse();

            try
            {
                if (tiket != null)
                {
                    tiket.fechaActualizacion = DateTime.Now;
                    _unitOfWork.Tiket.Actualizar(tiket);
                    _unitOfWork.Complete();
                    cr.success = 1;
                    cr.message = "Ticket Actualizado";
                    cr.data = tiket;
                }
                else
                {
                    cr.success = 0;
                    cr.message = "Ticket NO Actualizado";

                }


            }
            catch (Exception ex)
            {
                cr.success = 0;
                cr.message = ex.Message;



            }

            return cr;

        }

        [HttpDelete("[action]")]
        public CustomResponse EliminarTicket([FromBody] TicketModel tiket)
        {
            CustomResponse cr = new CustomResponse();

            try
            {
                if (tiket != null)
                {
                    _unitOfWork.Tiket.Eliminar(tiket);
                    _unitOfWork.Complete();
                    cr.success = 1;
                    cr.message = "Ticket Eliminado";
                    cr.data = tiket;
                }
                else
                {
                    cr.success = 0;
                    cr.message = "Ticket NO Eliminado";

                }


            }
            catch (Exception ex)
            {
                cr.success = 0;
                cr.message = ex.Message;



            }

            return cr;

        }


        [HttpPost("[action]")]
        public CustomResponse AgregarTiket([FromBody]TicketModel tiket)
        {
            CustomResponse cr = new CustomResponse();

            try{
                if(tiket!=null)
                {
                    _unitOfWork.Tiket.Guardar(tiket);
                    _unitOfWork.Complete();
                    cr.success = 1;
                    cr.message = "Ticket Creado";
                    cr.data = tiket;
                }
                else
                {
                    cr.success = 0;
                    cr.message = "Ticket NO Creado";
                    
                }
                
                
            }
            catch (Exception ex)
            {
                cr.success = 0;
                cr.message = ex.Message;
                


            }

            return cr;
            
        }



        [HttpGet("[action]")]
        public void CrearTikets()
        {
            TicketModel tiket = new TicketModel
                {
                usuario = "usuario1",
                fechaCreacion = DateTime.Now,
                estatus = true,
            };
            _unitOfWork.Tiket.Guardar(tiket);
            _unitOfWork.Complete();
            tiket = new TicketModel
            {
                usuario = "usuario2",
                fechaCreacion = DateTime.Now,
                estatus = true,
            };
            _unitOfWork.Tiket.Guardar(tiket);
            _unitOfWork.Complete();
            tiket = new TicketModel
            {
                usuario = "usuario3",
                fechaCreacion = DateTime.Now,
                estatus = true,
            };
            _unitOfWork.Tiket.Guardar(tiket);
            _unitOfWork.Complete();
            tiket = new TicketModel
            {
                usuario = "usuario4",
                fechaCreacion = DateTime.Now,
                estatus = true,
            };


        }
    }
}
