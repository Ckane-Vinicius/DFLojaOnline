using ApiProdutos.Application.Application_Interfaces;
using ApiProdutos.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : Controller
    {
        private readonly IProdutosApplication _produtosApplication;

        public ProdutosController(IProdutosApplication produtosApplication)
        {
            _produtosApplication = produtosApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _produtosApplication.GetAllItemsAsync());

        [HttpGet("count")]
        public async Task<IActionResult> GetCount() => Ok(await _produtosApplication.GetItemCountAsync());

        [HttpGet("search")]
        public async Task<IActionResult> GetByName([FromQuery] string nome) => Ok(await _produtosApplication.GetItemsByNameAsync(nome));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _produtosApplication.GetItemByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProdutosRequets dto)
        {
            var newproduto = await _produtosApplication.CreateItemAsync(dto);

            if(newproduto.Contains("Já existe um")) 
                return BadRequest();

            return Ok(newproduto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ProdutosRequets dto, int id)
        {            
            var updatedItem = await _produtosApplication.UpdateItemAsync(id, dto);

            if (updatedItem.Contains("Produto atualizado")) 
                 return Ok(updatedItem);

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _produtosApplication.DeleteItemAsync(id);

            return NoContent();
        }

    }
}
