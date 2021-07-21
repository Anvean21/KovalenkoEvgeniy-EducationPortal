using EducationPortal.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using EducationPortal.Command;

namespace EducationPortal
{
    class Program
    {
        static void Main(string[] args)
        {
            DependencyInjection.DependecyInjection.ConfigureService();
            IUserService userService = CustomServiceProvider.Provider.GetRequiredService<IUserService>();

            CommandManager commandManager = new CommandManager(CustomServiceProvider.Provider.GetRequiredService<ICommandProcessor>());

            while (true)
            {
                if (userService.IsUserAuthorized())
                {
                    commandManager.AuthStart();
                }
                else
                {
                    commandManager.Start();
                }
            }
        }
    }
}

