using Microsoft.AspNetCore.Mvc;
using APIProductsDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace APIProductsDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DbContextProducts _context = null;

        //Constructor
        public ProductsController(DbContextProducts context)
        {
            _context = context;
        }

        [HttpGet("List")]
        public List<Product> List()
        {
            return _context.Products.ToList();//Se envia la lista
        }

        //Metodo encargado de crear un producto
        [HttpPut("Create")]
        public string Create(Product temp)
        {
            string msj = "";
            try
            {
                //Se almacena el producto
                _context.Products.Add(temp);

                //Aplicar los cambios en la DB
                _context.SaveChanges();

                msj = $"Producto {temp.Name} almacenado correctamente";

                return msj;
            }//En caso de error se captura
            catch (Exception ex)
            {   //Se personaliza el error
                msj = $"Error {ex.InnerException.ToString()}";
                return msj;
                //Y se retorna
            }
        }
        //Metodo de modificar los datos
        [HttpPost("Update")]
        public async Task<string> Update(Product temp)
        {
            string msj = "";
            try
            {
                if(temp != null)
                {
                    Product prod = await _context.Products.FirstOrDefaultAsync(x => x.Code.Equals(temp.Code));
                    if (prod != null)
                    {
                        prod.Name = temp.Name;  
                        prod.Tax = temp.Tax;
                        prod.amount = temp.amount;
                        prod.Price = temp.Price;
                        prod.CreateDate = temp.CreateDate;
                        prod.Status = temp.Status;
                        _context.Products.Update(prod);

                        await _context.SaveChangesAsync();
                        return msj = $"Cambios aplicados correctamente al producto codigo {prod.Code}";
                    }
                    else
                    {
                        msj = $"Error el producto {temp.Name} no esta registrado";
                    }
                        
                }
                else
                {
                    msj = "No hay datos";
                }

                return msj;
            }
            catch (Exception ex)
            {
                return msj = $"Error {ex.InnerException.ToString()}";
            }
        }

        [HttpGet("Search")]
        public Product Search(string code)
        {
            Product temp = null;
            try
            {
                temp = _context.Products.FirstOrDefault(y => y.Code.Equals(code));
                return temp;
            }
            catch (Exception ex)
            {
                return temp;
            }
        }

        [HttpDelete("Delete")]
        public async Task<string> Delete(string code)
        {
            string msj = "";
            try
            {
                Product temp = await _context.Products.FirstOrDefaultAsync(j => j.Code.Equals(code));

                if (temp != null)
                {
                    _context.Products.Remove(temp);
                    await _context.SaveChangesAsync();
                    msj = $"Eliminado producto {temp.Name} correctamente..";
                }
                else
                {
                    return msj = $"No existe el producto con el codigo {code}";
                }
                return msj;
            }
            catch (Exception ex)
            {
                return msj = $"Error {ex.InnerException.ToString()}";
            }
        }

        [HttpGet("SearchName")]
        public List<Product> SearchName(string name)
        {
            return _context.Products.Where(x => x.Name.StartsWith(name)).ToList();
        }
    }
}
