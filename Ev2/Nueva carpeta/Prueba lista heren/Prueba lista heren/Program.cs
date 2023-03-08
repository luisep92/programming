namespace Prueba_lista_heren
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Obje obj = new Obje();

            Transf t = new Transf("1");
            obj.list.Add(t);
            SRen sren = new SRen("2");
            obj.list.Add(sren);
            obj.list[0].DoSmt();
            obj.list[1].DoSmt();
        }
    }
}