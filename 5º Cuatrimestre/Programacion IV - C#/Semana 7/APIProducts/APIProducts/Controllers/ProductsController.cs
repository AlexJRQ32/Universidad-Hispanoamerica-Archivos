using Microsoft.AspNetCore.Mvc;

//Referencia capa model
using APIProducts.Models;

namespace APIProducts.Controllers
{
    [ApiController] //permite al controlador usar los verbos del protocolo http
    [Route("[controller]")] //Implementación de rutas para el manejo de métodos
    public class ProductsController : ControllerBase
    {
        //Declarar una lista para almacenar objects
        private static List<Product> listado = null;


        //Constructor por omision
        //Se ejecuta de primero
        public ProductsController()
        {
            //Validacion se pregunta si está vacia
            if (listado == null)
            {
                //se instancia la lista
                listado = new List<Product>();

                LlenarLista();
            }

        }

        private void LlenarLista()
        {
            //Bloque de código para agregar una instancia de un object Product
            listado.Add(new Product
            {
                Code = 1,
                Descrip = "Atún",
                CreateDate = DateTime.Now,
                PurchasePrice = 1850,
                Quantity = 1,
                Status = 'A',
                Tax = 13
            });

            listado.Add(new Product
            {
                Code = 2,
                Descrip = "Frijoles",
                CreateDate = DateTime.Now,
                PurchasePrice = 980,
                Quantity = 3,
                Status = 'A',
                Tax = 13
            });
        }
        //Métodos public  para la API

        //Método encargado de extraer la lista
        [HttpGet]
        [Route("List")]
        public List<Product> List()
        {
            return listado;
        }

        //Método encargado de guardar un producto
        [HttpPut]
        [Route("Save")]
        public string Save(Product p)
        {
            string msj = "Save product..";

            if (p == null)
            {
                msj = "No data found..";
            }
            else
            {
                listado.Add(p); //se almacena el product
            }
            return msj;
        }

        //´Método encargado de eliminar un producto
        [HttpDelete]
        [Route("Delete")]
        public string Delete(int code)
        {
            //Mensaje al usuario
            string msj = "Deleted product...";

            //Se busca el producto por medio del código
            Product temp = listado.FirstOrDefault( g => g.Code == code );

            //Se valida si hay datos
            if (temp == null)
            {   //Mensaje en caso que no hay
                msj = "Product does not exist..";
            }
            else
            {   //si existe se elimina
                listado.Remove(temp);
            }
            return msj;  //se retorna el msj
        }

        [HttpPost]
        [Route("Update")]
        public string Update(Product p) {
            string msj = "Updated product"; //mensaje al user

            ///Search Product
            Product temp = listado.FirstOrDefault(x => x.Code == p.Code);

            //Validated data
            if (temp == null)
            {  //Mensaje user
                msj = "Product does not exist in list";
            }
            else
            {   //Remove list product
                listado.Remove(temp);
                //Add list product
                listado.Add(p);

            }
            return msj; //Message user
        }


        [HttpGet]
        [Route("Search")]
        public Product Search(int code)
        {
            return listado.FirstOrDefault(x => x.Code == code);
        }

    }//cierre controller
}
