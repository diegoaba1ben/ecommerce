using System;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Core.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; } // Id del producto

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del producto no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; } // Nombre del producto

        [Required(ErrorMessage = "La descripción del producto es obligatoria.")]
        [StringLength(500, ErrorMessage = "La descripción del producto no puede exceder los 500 caracteres.")]
        public string Descripcion { get; set; } // Descripción del producto

        [Required(ErrorMessage = "El precio del producto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio del producto debe ser mayor que 0.")]
        public float Precio { get; set; } // Precio del producto antes de impuestos

        [Required(ErrorMessage = "El subtotal es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El subtotal debe ser mayor que 0.")]
        public float SubTotal { get; set; } // Suma de impuestos y precio

        [Range(0, double.MaxValue, ErrorMessage = "El valor del flete debe ser mayor o igual a 0.")]
        public float? Flete { get; set; } // Valor del flete de envío (opcional)

        [Required(ErrorMessage = "Los impuestos son obligatorios.")]
        [Range(0, double.MaxValue, ErrorMessage = "El valor de los impuestos debe ser mayor o igual a 0.")]
        public float Impuestos { get; set; } // Impuestos aplicados sobre el producto

        [Required(ErrorMessage = "El monto total es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto total debe ser mayor que 0.")]
        public float MontoTotal { get; set; } // Suma de todos los valores que influyen en el valor final del producto

        [Required(ErrorMessage = "La imagen del producto es obligatoria.")]
        public byte[] Imagen { get; set; } // Fotografía del producto

        [Required(ErrorMessage = "La cantidad en inventario es obligatoria.")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad en inventario debe ser un número no negativo.")]
        public int Inventario { get; set; } // Cantidad de productos en inventario

        [Required(ErrorMessage = "El número de serie es obligatorio.")]
        [StringLength(50, ErrorMessage = "El número de serie no puede exceder los 50 caracteres.")]
        public string SerialNumber { get; set; } // Número de serie del producto
    }
}
