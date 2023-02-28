using GrupoColorado.Application.Interfaces;
using GrupoColorado.Application.Models;
using GrupoColorado.Application.Shared;
using GrupoColorado.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GrupoColorado.Customers.API.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerAppService _customerAppService;

    public CustomerController(ICustomerAppService customerAppService)
    {
        _customerAppService = customerAppService;
    }

    [HttpGet("{page}/{pageSize}")]
    public IActionResult Get(int page, int pageSize)
    {
        var result = _customerAppService.Get(page, pageSize);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(long id)
    {
        var result = _customerAppService.GetById(id);
        if (!result.Success && result.Data == null) return NotFound(result);

        return Ok(result);
    }

    [HttpGet("name/{name}/{page}/{pageSize}")]
    public IActionResult GetByName(int page, int pageSize, string name)
    {
        var result = _customerAppService.GetByName(page, pageSize, name);
        if (!result.Success && result.Data == null) return NotFound(result);

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create([FromBody] RegisterCustomerModel model)
    {
        var result = _customerAppService.Add(model);
        if (result.Success) return Ok(result);

        return BadRequest(result);
    }

    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody] UpdateCustomerModel model)
    {
        if (id != model.Id)
            return BadRequest(new Result(false, "Id informado deve ser igual ao Id informado no body", null));
       
        var result = _customerAppService.Update(id, model);
        if (result.Success) return Ok(result);

        return BadRequest(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var result = _customerAppService.Delete(id);
        if (result.Success) return Ok(result);

        return BadRequest(result);
    }
}