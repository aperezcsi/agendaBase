// See https://aka.ms/new-console-template for more information

using SiesaMenu;
using Test;

public class Program
{

    public static void Main(string[] args)
    {
        MenuDirectory menu = new MenuDirectory();
        ContactValidator contact = new ContactValidator();
        menu.Menu();
    }
}




