using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace IPSUPC.Controllers.Medicos
{

    [Route("api/[controller]")]

    public class MedicosController : ControllerBase
    {
        private readonly IMedicosBLL _medicosBLL;

        public MedicosController(IMedicosBLL medicosBLL)
        {
            _medicosBLL = medicosBLL;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _medicosBLL.GetMedicosAsync();
            return new OkObjectResult(result);
        }

        [HttpGet("GetById/{NumeroDocumento}")]
        public async Task<IActionResult> GetById(string NumeroDocumento)
        {
            var result = await _medicosBLL.GetMedicosByNumeroIdentificacionAsync(NumeroDocumento);
            return new OkObjectResult(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Medico medico)
        {
            var result = await _medicosBLL.CreateMedicosAsync(medico);
            return new OkObjectResult(result);
        }

        [HttpPut("Update/{NumeroDocumento}")]
        public async Task<IActionResult> Update([FromBody] Medico medico)
        {
            var result = await _medicosBLL.UpdateMedicosAsync(medico);
            return new OkObjectResult(result);
        }

        [HttpDelete("Delete/{NumeroDocumento}")]
        public async Task<IActionResult> Delete(string NumeroDocumento)
        {
            var result = await _medicosBLL.DeleteMedicosAsync(NumeroDocumento);
            return new OkObjectResult(result);
        }



    }
}