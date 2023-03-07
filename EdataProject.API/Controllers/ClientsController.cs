using EdataProject.Application.DTOs;
using EdataProject.Application.Interfaces;
using EdataProject.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdataProject.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;
    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDTO>>> Get()
    {
        var clients = await _clientService.GetClients();
        if (clients == null)
        {
            return NotFound("Clients not found");
        }
        return Ok(clients);
    }

    [HttpGet("{id}", Name = "GetClient")]
    public async Task<ActionResult<ClientDTO>> Get(int id)
    {
        var client = await _clientService.GetById(id);
        if (client == null)
        {
            return NotFound("Client not found");
        }
        return Ok(client);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ClientDTO clientDto)
    {
        if (clientDto == null)
            return BadRequest("Data Invalid");

        await _clientService.Add(clientDto);

        return new CreatedAtRouteResult("GetClient",
            new { id = clientDto.Id }, clientDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] ClientDTO clientDto)
    {
        if (id != clientDto.Id)
        {
            return BadRequest("Data invalid");
        }

        if (clientDto == null)
            return BadRequest("Data invalid");

        await _clientService.Update(clientDto);

        return Ok(clientDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ClientDTO>> Delete(int id)
    {
        var clientDto = await _clientService.GetById(id);

        if (clientDto == null)
        {
            return NotFound("Client not found");
        }

        await _clientService.Remove(id);

        return Ok(clientDto);
    }
}
