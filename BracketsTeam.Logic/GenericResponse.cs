using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Logic
{
    /// <summary>
    /// 
    /// </summary>
    public class GenericResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public GenericResponse() 
        {
            this.Registries = new List<GenericTable>();
        }

        /// <summary>
        /// 
        /// </summary>
        public List<GenericTable> Registries { get; set;}
    }

    /// <summary>
    /// 
    /// </summary>
    public class GenericTable
    {
        /// <summary>
        /// Constructor for a Generic "Table" for a GenericResponse
        /// </summary>
        /// <param name="idReg">Id of the registry added to the context</param>
        /// <param name="tName">Table Name of the added registry</param>
        public GenericTable(int idReg, string tName) 
        {
            this.IdRegistry = idReg;
            this.TableName = tName;
        }

        /// <summary>
        /// 
        /// </summary>
        public int IdRegistry { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public string TableName { get; private set; }
    }
}
