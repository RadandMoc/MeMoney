using System.ComponentModel.DataAnnotations;

namespace MeMoney.DBases
{
    public class Mem
    {

        [Key]
        public int IdMem { get ; set; }
        public string MemLink { get; set; }
    }
}
