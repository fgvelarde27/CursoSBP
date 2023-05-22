
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoSBP.Common.Models.Entities
{
    public class Campus
    {
        public int CampusId { get; set; }
        //define como llave foranea entre campus y student
        
        public HashSet<Student>? Student { get; set; }
        public string? CampusName { get; set; }
        public string? Address { get; set; }
        public Point Geography { get; set; }
        [MaxLength(500)]
        [Unicode(false)] //determina que el tipo de dato es de tipo varchar y no nvarchar.
        public string? Url { get; set; }

    }
  
}
