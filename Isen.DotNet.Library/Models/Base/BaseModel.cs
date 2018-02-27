namespace Isen.DotNet.Library.Models.Base
{
    public class BaseModel
    {
        public int Id{ get; set; }
        public virtual string Name { get; set; }
        public virtual string Display
        => $"[Id={Id}]|{Name}";

        public override string ToString()
        => Display;
    }
}