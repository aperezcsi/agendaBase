using SiesaDirectory;
using SiesaContact;

namespace Test
{

    public class TestDirectory
    {
        DirectorySiesa directory;
        Contact contact;
        int size;
        public TestDirectory()
        {
            directory = new DirectorySiesa(size);
        }

        public bool TestAddContact(string name, string landline, string cellphone)
        {   
            bool resp = directory.AddContact(new SiesaContact.Contact(name, landline, cellphone));
            if(resp == true){
                Console.WriteLine("PASS: Contacto agregado");
            }else{
                Console.WriteLine("FAIL: Contacto no se pudo agregar");
            }
            return resp;
        }
        public int TestFindContact(string name)
        {
            directory.AddContact(new SiesaContact.Contact("pepita", "12", "12"));
            int result = directory.FindContact(name);
            if (result == 1)
            {
                Console.WriteLine("Contacto Encontrado: PASS");
            }
            else if (result == 0)
            {
                Console.WriteLine("Contacto NO Encontrado: FAIL");
            }
            return result;
        }
        public bool TestListContact(){
            directory.AddContact(new SiesaContact.Contact("pepita", "12", "12"));
            bool resp = directory.ListContact();
            if(resp = true){
                Console.WriteLine("PASS: Contact Find");
            }
            else{
                Console.WriteLine("FAIL: Contact not Find");
            }
            return resp;
        }

        public bool TestListContactVoid(){
            bool resp = directory.ListContact();
            if(resp == true){
                Console.WriteLine("PASS: Contact Find");
            }
            else{
                Console.WriteLine("FAIL: Contact not Find");
            }
            return resp;
        }
        public bool TestDelete(string name)
        {   
            directory.AddContact(new SiesaContact.Contact("pepita", "12", "12"));
            bool resp = directory.DeleteContact(new SiesaContact.Contact(name, "null", "null"));
            if(resp == true){
                directory.FindContact(name);
            }else{
                Console.WriteLine("El contacto no existe");
            }
            return resp;
        }
        public bool TestDirectoryFull(int size)
        {
            bool resp = directory.FullDirectory();
            if (resp == true){
                Console.WriteLine("Agenda Llena");
            }
            else{
                Console.WriteLine("Agenda NO llena");
            }
            return resp;
        }
        public bool TestSpaceDirectory()
        {
            directory.SpacesDirectory();
            return true;
        }
    }

}