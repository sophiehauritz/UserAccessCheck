
class UserAccessCheck
{
    static void Main() // programmets startpunkt
    {
        // Activity 14: spørger user for input
        Console.Write("Enter username: "); // skriver teksten "enter username" i konsollen
        string username = Console.ReadLine(); // læser brugerens input og gemmer det som en tekststreng i variablen "username" 

        Console.Write("Enter password: "); // skriver teksten "enter password" i konsollen
        string password = Console.ReadLine(); // læser brugerens input og gemmer det i variablen "password"

        Console.Write("Enter user ID (number): "); // skriver teksten "enter user ID (number)" i konsollen
        uint userId = uint.Parse(Console.ReadLine()); // læser brugerens input og konverterer til et heltal

        // Activity 13: Boolean logic

        // sætter "userIsAdmin" til sand (true) hvis UserID er større end 65536, ellers falsk (false)
        bool userIsAdmin = userId > 65536;

        // sætter "usernameValid" til sand hvis brugernavnet har 3 eller flere tegn
        bool usernameValid = username.Length >= 3;

        // tjekker om kodeordet indeholer mindst et af tegnene $, |, @ og gemmer resultatet som sand eller falsk
        bool passwordContainsRequiredChar = password.Contains('$') || password.Contains('|') || password.Contains('@');

        // Hvis brugeren er admin kræves mindst 20 tegn i password, ellers mindst 16 tegn
        bool passwordLengthValid = userIsAdmin ? password.Length >= 20 : password.Length >= 16;

        // kodeordet er kun gyldigt hvis det både har de krævede tegn og er langt nok
        bool passwordValid = passwordContainsRequiredChar && passwordLengthValid;

        // Output beskeder
        if (usernameValid && passwordValid) // hvis brugernavn og kodeord er gyldige
        {
            Console.WriteLine("\n Access granted! Username and password are valid."); // skriver at adgang er givet
            if (userIsAdmin) // hvis brugeren er admin
            {
                Console.WriteLine("Welcome Admin!"); // skriver velkomstbesked
            }
            else // ellers (hvis ikke admin)
            {
                Console.WriteLine("Welcome User!"); // skriver velkomstbesked til almindelig bruger
            }
        }
        else // eller hvis brugernavn eller kodeord ikke er gyldigt
        {
            Console.WriteLine("\n Access denied. There were some problems:"); // skriver fejlbesked

            if (!usernameValid) // hvis brugernavnet ikke er gyldigt
                Console.WriteLine("- Username must have at least 3 characters."); // skriver hvorfor det er ugyldigt

            if (!passwordContainsRequiredChar) // hvis kodeordet ikke har de krævede tegn
                Console.WriteLine("- Password must contain at least one of the characters $, | or @."); // skriver kravene

            if (!passwordLengthValid) // hvis kodeordet ikke har korrekt længde
            {
                if (userIsAdmin) // hvis brugeren er admin
                    Console.WriteLine("- As an admin, your password must be at least 20 characters long."); // forklarer krav til admin
                else // hvis brugeren ikke er admin
                    Console.WriteLine("- As a user, your password must be at least 16 characters long."); // forklarer krav til bruger
            }
        }
    }
}
