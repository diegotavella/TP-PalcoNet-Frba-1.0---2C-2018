using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Dtos.Filters
{
    public class Pager
    {
        public Pager()
        {
            PageSize = 0;
            Page = 0;
        }

        /// <summary>
        /// La cantiad desde de registros que toma
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Cantidad de registros a tomar desde Page
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Nombre de la propiedad a ordenar
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        /// Ascendente si es true y descendente si es false
        /// </summary>
        public bool IsAsc { get; set; }

        // Pagina acual
        public int CurrentPage
        {
            get
            {
                return (this.Page - 1) * this.PageSize;
            }
        }
    }
}
