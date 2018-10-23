using GalaSoft.MvvmLight.Views;

namespace YGOmpanion.Services
{
    public interface IPlatformService
    {
        IDialogService CreateDialogServiceInstance();

        string GetDatabaseFilePath();
    }
}
