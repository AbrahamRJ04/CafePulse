namespace CafePulse.QA
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestGetAllGenero()
        {
           CafePulse.ModelClass.Result response = CafePulse.BusinessClass.Genero.GetAll();
            Assert.IsTrue(response.Success);

        }

        [TestMethod]
        public void TestGetAllRol()
        {
            CafePulse.ModelClass.Result response = CafePulse.BusinessClass.Rol.GetAll();
            Assert.IsTrue(response.Success);
        }
        
        [TestMethod]
        public void TesLoginSP()
        {
            string Usuario = "reyesoa";
            string Contrasena = "WELCOME001";

            CafePulse.ModelClass.Result response = CafePulse.BusinessClass.Usuario.GetAuthenticationLog(Usuario,Contrasena);
            Assert.IsTrue(response.Success);
        }
    }
}
