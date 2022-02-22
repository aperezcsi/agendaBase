using SiesaDirectory;
using SiesaContact;
using FluentValidation;

namespace SiesaMenu
{
    // Opciones de la agenda telefónica
    enum Options
    {
        addContact = 1,
        listContact = 2,
        searchContact = 3,
        existContact = 4,
        deleteContact = 5,
        availableContact = 6,
        fullDirectory = 7,
        exit = 8,
    }
    //Valor min y max para la agenda
    enum CantContacts
    {
        minContacts = 0,
        maxContacts = 10,
    }
    public class MenuDirectory
    {
        int size;
        string name;
        string home;
        string cellphone;
        public void Menu()
        {
            DirectorySiesa directory = new DirectorySiesa(size);
            Contact contact = new Contact(name, home, cellphone);
            ContactValidator validator = new ContactValidator();
            string optionUser;
            int option = 0;
            do
            {
                Console.Write("¿Cual será el tamaño de la agenda? \n");
                size = int.Parse(Console.ReadLine());
                directory.setSize(size);

                if (size > (int)CantContacts.minContacts && size <= (int)CantContacts.maxContacts)
                {
                    do
                    {
                        Console.Write("\nAgenda Telefonica \n1. Adicionar Contacto \n2. Listar Contactos\n3. Buscar Contacto\n4. Existe Contacto\n5. Eliminar Contacto\n6. Contacto Disponible\n7. Agenda Llena\n8. Salir");

                        Console.WriteLine("\nIngrese el número de la operación: ");
                        optionUser = Console.ReadLine();

                        if (optionUser.All(char.IsDigit))
                        {
                            option = int.Parse(optionUser);

                            switch (option)
                            {
                                case (int)Options.addContact:
                                    if (!directory.FullDirectory())
                                    {
                                        InfoContact();
                                        contact = new Contact(name, home, cellphone);
                                        
                                        FluentValidation.Results.ValidationResult results = validator.Validate(contact); // Mira las reglas, valida y almacena el resultado

                                        if (!results.IsValid)
                                        {
                                            foreach (var failure in results.Errors)
                                            {
                                                Console.WriteLine(failure.ErrorMessage + " Intente de nuevo");
                                            }
                                        }
                                        else{
                                                directory.AddContact(contact);
                                        }
                                    }
                                    break;

                                case (int)Options.listContact:
                                    directory.ListContact();
                                    break;

                                case (int)Options.searchContact:

                                    nameContact();
                                    contact = new Contact(name, null, null);
                                    directory.FindContact(name);
                                    break;

                                case (int)Options.existContact:

                                    nameContact();
                                    contact = new Contact(name, null, null);
                                    directory.ExistContact(contact);
                                    break;

                                case (int)Options.deleteContact:
                                    nameContact();
                                    contact = new Contact(name, null, null);
                                    directory.DeleteContact(contact);
                                    break;

                                case (int)Options.availableContact:
                                    directory.SpacesDirectory();
                                    break;

                                case (int)Options.fullDirectory:
                                    if (!directory.FullDirectory())
                                        Console.WriteLine("\nLa agenda aun no esta llena \n");
                                    break;

                                case (int)Options.exit:
                                    Console.WriteLine("\nHasta Luego! :) \n");
                                    break;
                            }
                        }
                        else
                        {
                            Console.Write("\nOpción no valida. Porfavor intenta con otra opción\n");
                        }
                    } while (option != (int)Options.exit);
                }
                else
                {
                    Console.Write("La agenda puede tener máximo 10 contactos \n");
                }
            } while (size <= (int)CantContacts.minContacts || size > (int)CantContacts.maxContacts);
        }
        public void InfoContact()
        {
            Console.Write("\n");
            Console.Write("Nombre del contacto: ");
            name = Convert.ToString(Console.ReadLine());

            Console.Write(@"Número Fijo: ");
            home = Convert.ToString(Console.ReadLine());

            Console.Write(@"Número de Celular: ");
            cellphone = Convert.ToString(Console.ReadLine());
        }
        public void nameContact()
        {
            Console.Write("\nPorfavor ingrese el nombre del contacto:  ");
            name = Convert.ToString(Console.ReadLine());
        }
    }
}
