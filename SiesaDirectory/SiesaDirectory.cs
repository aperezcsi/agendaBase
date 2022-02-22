using SiesaContact;

namespace SiesaDirectory
{
    enum Result
    {
        failure = 0,
        success = 1,
    }

    public class DirectorySiesa
    {
        public List<Contact> ArrayContacts = new List<Contact>();
        public int size;

        public DirectorySiesa(int size){
            size=size;
        }
        public int getSize() { return size; }
        public void setSize(int size){ this.size=size; }
        
        //Agrega contacto a la Agenda
        public bool AddContact(Contact contact)
        {
            if (ArrayContacts.Count != 0)
            {
                if (ExistContact(contact) == false)
                {
                    ArrayContacts.Add(contact);
                    Console.Write("\nContacto Creado correctamente \n");
                    return true;
                }else{
                    return false;
                }
            }
            else
            {
                ArrayContacts.Add(contact);
                Console.WriteLine("\nContacto Creado correctamente \n");
                return true;
            }
            return false;
        }

        //Lista los contactos que se tiene en la Agenda
        public bool ListContact()
        {
            bool res = false;
            if(ArrayContacts.Count != 0)
            {
                int incremental = 1;

                Console.WriteLine("\nLista de Contactos: \n");
                foreach (Contact item in ArrayContacts)
                {
                    Console.Write(incremental + @".  Nombre: " + item._name+"\n" +
                    @"    Fijo: " + item._landline +"\n"+
                    @"    Celular: " + item._cellphone+"\n");
                    incremental++;
                    res=true;
                }
                Console.WriteLine("\n");
            }else{
                Console.WriteLine("No hay contactos para mostrar");
            }
            return res;
        }

        //Busca un contacto en la agenda telefonica
        public int FindContact(string name)
        {
            foreach (Contact item in ArrayContacts)
            {
                if (item._name.Equals(name))
                {
                    Console.Write("\n Nombre: " + name +"\n"+ 
                    " Fijo: " + item._landline +"\n"+
                    " Celular " + item._cellphone);
                    Console.WriteLine("\n");
                    return (int)Result.success;
                }
            }
            Console.Write("\n El contacto No existe \n");
            return (int)Result.failure;
        }

        //Verifica si existe un contacto en la Agenda
        public bool ExistContact(Contact contact)
        {
            foreach (Contact item in ArrayContacts)
            {
                if (contact._name.Equals(item._name))
                {
                    Console.WriteLine("El contacto ya existe \n");
                    return true;
                }
            }
            Console.WriteLine("El contacto No existe \n");
            return false;
        }
        
        //Borrar contacto de la Agenda
        public bool DeleteContact(Contact contact)
        {
            foreach (Contact item in ArrayContacts)
            {
                if (item._name.Equals(contact._name))
                {
                    ArrayContacts.Remove(item);
                    Console.Write("\nContacto Eliminado satisfactoriamente \n");
                    return true;
                }
            }
            return false;
        }

        //Verifica si el directorio esta lleno
        public bool FullDirectory()
        {
            if (ArrayContacts.Count == size)
            {
                Console.Write("Agenda está llena \n");
                return true;
            }
            return false;
        }

        //Verifica el espacio actual en la Agenda
        public void SpacesDirectory()
        {
            int count = size - ArrayContacts.Count();
            Console.Write("Contactos disponbles " + count + "\n");
        }
    }
}
